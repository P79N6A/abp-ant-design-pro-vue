using JetBrains.Annotations;

namespace Niue.Abp.Abp.MultiTenancy
{
    public interface ITenantResolverCache
    {
        [CanBeNull]
        TenantResolverCacheItem Value { get; set; }
    }
}