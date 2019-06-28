using System.Web;
using Niue.Abp.Abp.Dependency;
using Niue.Abp.Abp.Extensions;
using Niue.Abp.Abp.MultiTenancy;

namespace Niue.Abp.Abp.Web.Web.MultiTenancy
{
    public class HttpCookieTenantResolveContributor : ITenantResolveContributor, ITransientDependency
    {
        public int? ResolveTenantId()
        {
            var cookie = HttpContext.Current?.Request.Cookies[MultiTenancyConsts.TenantIdResolveKey];
            if (cookie == null || cookie.Value.IsNullOrEmpty())
            {
                return null;
            }

            int tenantId;
            return !int.TryParse(cookie.Value, out tenantId) ? (int?) null : tenantId;
        }
    }
}