using BaseCore.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace BaseCore.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder AuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }    
        public static IApplicationBuilder ExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
