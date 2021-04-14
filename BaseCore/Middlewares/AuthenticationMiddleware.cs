using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BaseCore.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _nextMiddleWare;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _nextMiddleWare = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var jwToken = context.Session.GetString("JWToken");

            if (!string.IsNullOrEmpty(jwToken))
                context.Request.Headers.Add("Authorization", "Bearer " + jwToken);

            await _nextMiddleWare(context);
        }
    }
}