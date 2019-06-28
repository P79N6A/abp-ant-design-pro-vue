using System.Reflection;
using System.Web.Http.Controllers;
using Niue.Abp.Abp.Extensions;

namespace Niue.Abp.Abp.Web.Api.WebApi.Validation
{
    public static class ActionDescriptorExtensions
    {
        public static MethodInfo GetMethodInfoOrNull(this HttpActionDescriptor actionDescriptor)
        {
            if (actionDescriptor is ReflectedHttpActionDescriptor)
            {
                return actionDescriptor.As<ReflectedHttpActionDescriptor>().MethodInfo;
            }
            
            return null;
        }

        public static bool IsDynamicAbpAction(this HttpActionDescriptor actionDescriptor)
        {
            return actionDescriptor
                .ControllerDescriptor
                .Properties
                .ContainsKey("__AbpDynamicApiControllerInfo");
        }
    }
}