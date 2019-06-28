using System;

namespace Niue.Abp.Abp.Web.Web.Security.AntiForgery
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method)]
    public class DisableAbpAntiForgeryTokenValidationAttribute : Attribute
    {

    }
}
