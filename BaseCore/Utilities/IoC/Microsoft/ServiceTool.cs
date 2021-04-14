using Microsoft.Extensions.DependencyInjection;
using System;

namespace BaseCore.Utilities.IoC.Microsoft
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection service)
        {
            ServiceProvider = service.BuildServiceProvider();
            return service;
        }
    }
}
