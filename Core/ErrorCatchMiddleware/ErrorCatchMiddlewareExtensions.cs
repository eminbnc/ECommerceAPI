using Microsoft.AspNetCore.Builder;

namespace Core.ErrorCatchMiddleware
{
    public static class ErrorCatchMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorCatchMiddleware>();
        }
    }
}
