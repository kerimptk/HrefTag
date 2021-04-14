using BaseCore.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace BaseCore.Extensions
{
    public static class ErrorExtension
    {
        public static IApplicationBuilder ErrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}