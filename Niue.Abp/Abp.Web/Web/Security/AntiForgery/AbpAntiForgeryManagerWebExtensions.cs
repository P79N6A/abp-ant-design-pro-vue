using System.Reflection;
using Niue.Abp.Abp.Reflection;
using Niue.Abp.Abp.Web.Common.Web;
using Niue.Abp.Abp.Web.Common.Web.Security.AntiForgery;

namespace Niue.Abp.Abp.Web.Web.Security.AntiForgery
{
    public static class AbpAntiForgeryManagerWebExtensions
    {
        public static bool ShouldValidate(
            this IAbpAntiForgeryManager manager,
            IAbpAntiForgeryWebConfiguration antiForgeryWebConfiguration,
            MethodInfo methodInfo, 
            HttpVerb httpVerb, 
            bool defaultValue)
        {
            if (!antiForgeryWebConfiguration.IsEnabled)
            {
                return false;
            }

            if (methodInfo.IsDefined(typeof(ValidateAbpAntiForgeryTokenAttribute), true))
            {
                return true;
            }

            if (ReflectionHelper.GetSingleAttributeOfMemberOrDeclaringTypeOrDefault<DisableAbpAntiForgeryTokenValidationAttribute>(methodInfo) != null)
            {
                return false;
            }

            if (antiForgeryWebConfiguration.IgnoredHttpVerbs.Contains(httpVerb))
            {
                return false;
            }

            if (methodInfo.DeclaringType?.IsDefined(typeof(ValidateAbpAntiForgeryTokenAttribute), true) ?? false)
            {
                return true;
            }

            return defaultValue;
        }
    }
}
