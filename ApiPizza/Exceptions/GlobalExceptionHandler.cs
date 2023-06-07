
using System.Net;
using System.Text.Json;

namespace ApiPizza.Exceptions
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionHandler(RequestDelegate _next)
        {
            this._next = _next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this._next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        public static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            //estructura del ErrorResponseDto
            HttpStatusCode statusCode;
            DateTime timeStamp = DateTime.Now;
            string message;
            string stackTrace;

            // Obteniendo el tipo de exception
            var exType = ex.GetType();

            if (exType == typeof(ApiPizza.Exceptions.BadRequestException))
            {
                statusCode = HttpStatusCode.BadRequest;
            }
            else if (exType == typeof(ApiPizza.Exceptions.KeyNotFoundException))
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            else if (exType == typeof(ApiPizza.Exceptions.NotFoundException))
            {
                statusCode = HttpStatusCode.NotFound;
            }
            else if (exType == typeof(ApiPizza.Exceptions.UnauthorizedException))
            {
                statusCode = HttpStatusCode.Unauthorized;

            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
            }

            message = ex.Message;
            stackTrace = ex.StackTrace;

            var ErrorResponseDto = JsonSerializer.Serialize(new
            {
                timeStamp, message, stackTrace, statusCode
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(ErrorResponseDto);

        }
    }
}
