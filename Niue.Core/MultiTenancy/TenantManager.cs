using Niue.Abp.Abp.Domain.Repositories;
using Niue.Abp.Zero.Abp.Zero.Application.Features;
using Niue.Abp.Zero.Abp.Zero.MultiTenancy;
using Niue.Core.Editions;
using Niue.Core.Users;

namespace Niue.Core.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore
            ) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore
            )
        {
        }
    }
}