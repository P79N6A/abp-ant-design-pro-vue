using System.Web;
using Niue.Abp.Abp.Dependency;
using Niue.Abp.Abp.MultiTenancy;

namespace Niue.Abp.Abp.Web.Web.MultiTenancy
{
    public class HttpContextTenantResolverCache : ITenantResolverCache, ITransientDependency
    {
        private const string CacheItemKey = "Abp.MultiTenancy.TenantResolverCacheItem";

        public TenantResolverCacheItem Value
        {
            get
            {
                return HttpContext.Current?.Items[CacheItemKey] as TenantResolverCacheItem;
            }

            set
            {
                var httpContext = HttpContext.Current;
                if (httpContext == null)
                {
                    return;
                }

                httpContext.Items[CacheItemKey] = value;
            }
        }
    }
}
