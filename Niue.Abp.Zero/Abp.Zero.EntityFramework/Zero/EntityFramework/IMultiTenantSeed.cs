using Niue.Abp.Zero.Abp.Zero.MultiTenancy;

namespace Niue.Abp.Zero.Abp.Zero.EntityFramework.Zero.EntityFramework
{
    public interface IMultiTenantSeed
    {
        AbpTenantBase Tenant { get; set; }
    }
}