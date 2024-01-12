using CompleteApiSample.Errors;
using System.Net;
using System.Text.Json;

namespace CompleteApiSample.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(
            RequestDelegate next,
            IHostEnvironment env)
        {
            _env = env;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = _env.IsDevelopment()
                ? new ErrorMessage
                {
                    StatusCode = context.Response.StatusCode,
                    Message = exception.Message,
                    Stacktrace = exception.StackTrace?.ToString(),
                }
                : new ErrorMessage
                {
                    StatusCode = context.Response.StatusCode,
                    Message = exception.Message,
                };
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }
    }
}
