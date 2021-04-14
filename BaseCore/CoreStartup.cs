using BaseCore.Utilities.Extensions;
using BaseCore.Utilities.IoC.Microsoft;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BaseCore
{
    public class CoreStartup : ICoreModule
    {
        public void Load(IServiceCollection services)
        {

            services.AddControllersWithViews();

            services.AddRouting();

            services.CreateAutofacServiceProvider();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHttpContextAccessor();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = false;
                options.Cookie.IsEssential = true;
            });

        }
    }

}
