using BaseCore;
using BaseCore.Utilities.Extensions;
using BaseCore.Utilities.IoC.Microsoft;
using Blog.Application.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HrefTag.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
           
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencyResolvers(new ICoreModule[] { new CoreStartup() });
            BlogStartupExtension.ConfigureServices(services, Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            MiddlewareModule.Configure(app, env);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                   name: "Admin",
                   areaName: "Admin",
                   pattern: "Admin/{Controller=Home}/{action=index}/{id?}");


                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Blog}/{action=Index}/{id?}");

                //endpoints.MapControllerRoute(
                //        name: "blog",
                //        pattern: "{*article}",
                //        defaults: new { controller = "Blog", action = "Yazi" });

                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Kategori}/{action=Index}/{UrlAd}");

                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Blog}/{action=Yazi}/{UrlBaslik}");

                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{Controller=EditorunSectikleri}/{action=index}");

                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{Controller=Araclar}/{action=Index}");
            });
        }
    }
}
