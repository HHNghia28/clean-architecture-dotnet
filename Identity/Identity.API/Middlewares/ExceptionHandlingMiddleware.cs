using Identity.API.Filters;
using Identity.Application.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Identity.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
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

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception, int statusCode, string message)
        {
            var apiResponse = new APIResponse<string>
            {
                StatusCode = statusCode,
                Message = message,
                Success = statusCode == StatusCodes.Status200OK,
                Data = null
            };

            var jsonResponse = System.Text.Json.JsonSerializer.Serialize(apiResponse);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(jsonResponse);
        }
    }

}
