using Niue.Abp.Abp.Application.Features;
using Niue.Abp.Abp.Domain.Repositories;
using Niue.Abp.Abp.Domain.Uow;
using Niue.Abp.Abp.Runtime.Caching;
using Niue.Abp.Zero.Abp.Zero.Application.Features;
using Niue.Abp.Zero.Abp.Zero.MultiTenancy;
using Niue.Core.MultiTenancy;
using Niue.Core.Users;

namespace Niue.Core.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, User>
    {
        public FeatureValueStore(
            ICacheManager cacheManager, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            IRepository<Tenant> tenantRepository, 
            IRepository<EditionFeatureSetting, long> editionFeatureRepository, 
            IFeatureManager featureManager, 
            IUnitOfWorkManager unitOfWorkManager) 
            : base(cacheManager, 
                  tenantFeatureRepository, 
                  tenantRepository, 
                  editionFeatureRepository, 
                  featureManager, 
                  unitOfWorkManager)
        {
        }
    }
}