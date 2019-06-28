using System.Linq;
using System.Web.Http.Controllers;
using Niue.Abp.Abp.Collections.Extensions;
using Niue.Abp.Abp.Web.Models;

namespace Niue.Abp.Abp.Web.Api.WebApi.Controllers
{
    internal static class HttpActionDescriptorHelper
    {
        public static WrapResultAttribute GetWrapResultAttributeOrNull(HttpActionDescriptor actionDescriptor)
        {
            if (actionDescriptor == null)
            {
                return null;
            }

            //Try to get for dynamic APIs (dynamic web api actions always define __AbpDynamicApiDontWrapResultAttribute)
            var wrapAttr = actionDescriptor.Properties.GetOrDefault("__AbpDynamicApiDontWrapResultAttribute") as WrapResultAttribute;
            if (wrapAttr != null)
            {
                return wrapAttr;
            }

            //Get for the action
            wrapAttr = actionDescriptor.GetCustomAttributes<WrapResultAttribute>(true).FirstOrDefault();
            if (wrapAttr != null)
            {
                return wrapAttr;
            }

            //Get for the controller
            wrapAttr = actionDescriptor.ControllerDescriptor.GetCustomAttributes<WrapResultAttribute>(true).FirstOrDefault();
            if (wrapAttr != null)
            {
                return wrapAttr;
            }

            //Not found
            return null;
        }
    }
}