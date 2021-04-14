using BaseCore.Utilities.Enum;
using BaseCore.Utilities.Helpers;
using BaseCore.Utilities.IoC.Microsoft;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using PostSharp.Serialization;

namespace BaseCore.Aspects.MVC
{
    [PSerializable]
    [MulticastAttributeUsage(MulticastTargets.Method)]
    public class PopupAlertAspect : OnMethodBoundaryAspect
    {
        public string Message = "";

        [PNonSerialized]
        private IHttpContextAccessor _httpContextAccessor;

        public override void OnSuccess(MethodExecutionArgs args)
        {
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            new AlertCore(_httpContextAccessor).Alert("Success", "Success", SweetAlertNotificationType.success);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            new AlertCore(_httpContextAccessor).Alert("Error", "there is something wrong", SweetAlertNotificationType.error);
        }
    }
}
