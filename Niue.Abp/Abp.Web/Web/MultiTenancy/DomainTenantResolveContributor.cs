using System;
using System.Web;
using Niue.Abp.Abp.Dependency;
using Niue.Abp.Abp.Extensions;
using Niue.Abp.Abp.MultiTenancy;
using Niue.Abp.Abp.Text;
using Niue.Abp.Abp.Web.Common.Web.MultiTenancy;

namespace Niue.Abp.Abp.Web.Web.MultiTenancy
{
    public class DomainTenantResolveContributor : ITenantResolveContributor, ITransientDependency
    {
        private readonly IWebMultiTenancyConfiguration _multiTenancyConfiguration;
        private readonly ITenantStore _tenantStore;

        public DomainTenantResolveContributor(
            IWebMultiTenancyConfiguration multiTenancyConfiguration,
            ITenantStore tenantStore)
        {
            _multiTenancyConfiguration = multiTenancyConfiguration;
            _tenantStore = tenantStore;
        }

        public int? ResolveTenantId()
        {
            if (_multiTenancyConfiguration.DomainFormat.IsNullOrEmpty())
            {
                return null;
            }

            var httpContext = HttpContext.Current;
            if (httpContext == null)
            {
                return null;
            }

            var hostName = httpContext.Request.Url.Host.RemovePreFix("http://", "https://");
            var result = new FormattedStringValueExtracter().Extract(hostName, _multiTenancyConfiguration.DomainFormat, true);
            if (!result.IsMatch)
            {
                return null;
            }

            var tenancyName = result.Matches[0].Value;
            if (tenancyName.IsNullOrEmpty())
            {
                return null;
            }

            if (string.Equals(tenancyName, "www", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            var tenantInfo = _tenantStore.Find(tenancyName);
            if (tenantInfo == null)
            {
                return null;
            }

            return tenantInfo.Id;
        }
    }
}