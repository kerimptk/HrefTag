using Autofac;
using Autofac.Extensions.DependencyInjection;
using BaseCore.Utilities.IoC.Microsoft;
using Microsoft.Extensions.DependencyInjection;
using System;
using Module = Autofac.Module;

namespace BaseCore.Utilities.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private static IContainer _container;

        public static IServiceCollection AddDependencyResolvers(this IServiceCollection service, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(service);
            }
            return ServiceTool.Create(service);
        }

        public static IServiceCollection AddAutofacDependencyResolvers(this IServiceCollection services, Module[] modules)
        {

            var builder = new ContainerBuilder();
            builder.Populate(services);

            foreach (var module in modules)
            {
                builder.RegisterModule(module);
            }

            _container = builder.Build();

            return services;
        }

        public static IServiceProvider CreateAutofacServiceProvider(this IServiceCollection services)
        {
            return new AutofacServiceProvider(_container);
        }
    }
}
