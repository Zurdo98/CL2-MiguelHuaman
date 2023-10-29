using System.Net;
using System.Text.Json;
//
using NotFoundExceptions = CL2_MiguelHuaman.Exceptions.NotFoundExceptions;
  
namespace CL2_MiguelHuaman.Exceptions
{
    public class GlobalExceptionsHandler
    {
        public readonly RequestDelegate _next;
        public GlobalExceptionsHandler(RequestDelegate _next)
        {
            this._next = _next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandlerExceptionAsync(context, ex);
            }
        }
        private static Task HandlerExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode;
            DateTime timeStamp = DateTime.Now;
            string? stackTrace;
            string message;

            var exType = ex.GetType();
            if (exType == typeof(NotFoundExceptions))
            {
                statusCode = HttpStatusCode.NotFound;
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
            }

            message = ex.Message;
            stackTrace = ex.StackTrace;
            var exceptionResult = JsonSerializer.Serialize(new
            {
                error = timeStamp,
                message,
                stackTrace,
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(exceptionResult);

        }
    }
}
