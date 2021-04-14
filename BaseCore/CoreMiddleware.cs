using BaseCore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BaseCore
{
    public class MiddlewareModule
    {
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCookiePolicy();
            app.AuthenticationMiddleware();
            app.ExceptionMiddleware();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }

}
