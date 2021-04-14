using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BaseCore.Extensions
{
    public interface IStartup
    {
        public void ConfigureServices(IServiceCollection services);
        public void Configure(IApplicationBuilder app);
    }
}
