using Identity.Application.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Identity.API.Middlewares
{
    public class ApiResponseMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            try
            {
                await next(context);

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
                await HandleExceptionAsync(context, originalBodyStream, StatusCodes.Status404NotFound, ex.Message);
            }
            catch (ValidationException ex)
            {
                await HandleExceptionAsync(context, originalBodyStream, StatusCodes.Status400BadRequest, ex.Message);
            }
            catch
            {
                await HandleExceptionAsync(context, originalBodyStream, StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Stream originalBodyStream, int statusCode, string message)
        {
            context.Response.Body = originalBodyStream;

            var apiResponse = new
            {
                Success = false,
                StatusCode = statusCode,
                Message = GetMessageByStatusCode(statusCode),
                Data = message
            };

            var response = JsonSerializer.Serialize(apiResponse);

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(response);
        }

        private string GetMessageByStatusCode(int statusCode)
        {
            return statusCode switch
            {
                100 => "Continue",
                101 => "Switching Protocols",
                102 => "Processing",
                200 => "OK",
                201 => "Created",
                202 => "Accepted",
                203 => "Non-Authoritative Information",
                204 => "No Content",
                205 => "Reset Content",
                206 => "Partial Content",
                207 => "Multi-Status",
                208 => "Already Reported",
                226 => "IM Used",
                300 => "Multiple Choices",
                301 => "Moved Permanently",
                302 => "Found",
                303 => "See Other",
                304 => "Not Modified",
                305 => "Use Proxy",
                307 => "Temporary Redirect",
                308 => "Permanent Redirect",
                400 => "Bad Request",
                401 => "Unauthorized",
                402 => "Payment Required",
                403 => "Forbidden",
                404 => "Not Found",
                405 => "Method Not Allowed",
                406 => "Not Acceptable",
                407 => "Proxy Authentication Required",
                408 => "Request Timeout",
                409 => "Conflict",
                410 => "Gone",
                411 => "Length Required",
                412 => "Precondition Failed",
                413 => "Payload Too Large",
                414 => "URI Too Long",
                415 => "Unsupported Media Type",
                416 => "Range Not Satisfiable",
                417 => "Expectation Failed",
                418 => "I'm a Teapot",
                421 => "Misdirected Request",
                422 => "Unprocessable Entity",
                423 => "Locked",
                424 => "Failed Dependency",
                426 => "Upgrade Required",
                428 => "Precondition Required",
                429 => "Too Many Requests",
                431 => "Request Header Fields Too Large",
                451 => "Unavailable For Legal Reasons",
                500 => "Internal Server Error",
                501 => "Not Implemented",
                502 => "Bad Gateway",
                503 => "Service Unavailable",
                504 => "Gateway Timeout",
                505 => "HTTP Version Not Supported",
                506 => "Variant Also Negotiates",
                507 => "Insufficient Storage",
                508 => "Loop Detected",
                510 => "Not Extended",
                511 => "Network Authentication Required",
                _ => "Unknown"
            };
        }
    }

}
