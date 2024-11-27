using Product.Application.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Product.API.Middlewares
{
    public class ApiResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            try
            {
                await _next(context);

                context.Response.Body = originalBodyStream;

                var statusCode = context.Response.StatusCode;
                var isSuccess = statusCode >= 200 && statusCode < 300;

                responseBody.Seek(0, SeekOrigin.Begin);
                var bodyContent = await new StreamReader(responseBody).ReadToEndAsync();

                var apiResponse = new
                {
                    Success = isSuccess,
                    StatusCode = statusCode,
                    Message = GetMessageByStatusCode(statusCode),
                    Data = isSuccess ? JsonSerializer.Deserialize<object>(bodyContent) : null
                };

                var response = JsonSerializer.Serialize(apiResponse);

                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(context, ex, StatusCodes.Status404NotFound, ex.Message);
            }
            catch (ValidationException ex)
            {
                await HandleExceptionAsync(context, ex, StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception, int statusCode, string message)
        {
            var apiResponse = new
            {
                Success = false,
                StatusCode = statusCode,
                Message = GetMessageByStatusCode(statusCode),
                Data = exception.Message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(apiResponse));
        }

        private string GetMessageByStatusCode(int statusCode) =>
            statusCode switch
            {
                200 => "OK",
                201 => "Created",
                400 => "Bad Request",
                404 => "Not Found",
                500 => "Internal Server Error",
                _ => "Unknown"
            };
    }

}
