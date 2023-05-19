using Expert.Core.Exceptions;
using Expert.Core.Requests;
using System.Net;

namespace Expert.Api.Middlewares
{
    public static class ErrorHandlerExtensions
    {
        public static IApplicationBuilder UseMediaErrorHandler(this IApplicationBuilder app)
            => app.UseMiddleware<MediaErrorHandlerMiddleware>();
    }

    public class MediaErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public MediaErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var result = GetExceptionResponse(ex);

                context.Response.StatusCode = ex switch
                {
                    FriendlyException => (int)HttpStatusCode.BadRequest,
                    _ => (int)HttpStatusCode.InternalServerError
                };

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(result);
            }
        }

        public ApiResponse<object> GetExceptionResponse(Exception exception) => exception switch
        {
            FriendlyException ex => ApiResponse<object>.Create(null, new List<string>() { ex.Message }, ""),
            _ => ApiResponse<object>.Create(null, new List<string>() { "Something went wrong" }, ""),
        };
    }
}
