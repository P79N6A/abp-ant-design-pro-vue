using Niue.Abp.Abp.Dependency;
using Niue.Abp.Abp.Events.Bus.Entities;
using Niue.Abp.Abp.Events.Bus.Handlers;
using Niue.Abp.Abp.Runtime.Caching;
using Niue.Abp.Zero.Abp.Zero.Runtime.Caching;

namespace Niue.Abp.Zero.Abp.Zero.Authorization.Roles
{
    public class AbpRolePermissionCacheItemInvalidator :
        IEventHandler<EntityChangedEventData<RolePermissionSetting>>,
        IEventHandler<EntityDeletedEventData<AbpRoleBase>>,
        ITransientDependency
    {
        private readonly ICacheManager _cacheManager;

        public AbpRolePermissionCacheItemInvalidator(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public void HandleEvent(EntityChangedEventData<RolePermissionSetting> eventData)
        {
            var cacheKey = eventData.Entity.RoleId + "@" + (eventData.Entity.TenantId ?? 0);
            _cacheManager.GetRolePermissionCache().Remove(cacheKey);
        }

        public void HandleEvent(EntityDeletedEventData<AbpRoleBase> eventData)
        {
            var cacheKey = eventData.Entity.Id + "@" + (eventData.Entity.TenantId ?? 0);
            _cacheManager.GetRolePermissionCache().Remove(cacheKey);
        }
    }
}