using Microsoft.Extensions.DependencyInjection;

namespace BaseCore.Utilities.IoC.Microsoft
{
    public interface ICoreModule
    {
        void Load(IServiceCollection service);
    }
}
