using Niue.Abp.Abp.Dependency;
using Niue.Abp.Abp.Events.Bus.Entities;
using Niue.Abp.Abp.Events.Bus.Handlers;
using Niue.Abp.Abp.Runtime.Caching;
using Niue.Abp.Zero.Abp.Zero.Runtime.Caching;

namespace Niue.Abp.Zero.Abp.Zero.Authorization.Users
{
    public class AbpUserPermissionCacheItemInvalidator :
        IEventHandler<EntityChangedEventData<UserPermissionSetting>>,
        IEventHandler<EntityChangedEventData<UserRole>>,
        IEventHandler<EntityDeletedEventData<AbpUserBase>>,

        ITransientDependency
    {
        private readonly ICacheManager _cacheManager;

        public AbpUserPermissionCacheItemInvalidator(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public void HandleEvent(EntityChangedEventData<UserPermissionSetting> eventData)
        {
            var cacheKey = eventData.Entity.UserId + "@" + (eventData.Entity.TenantId ?? 0);
            _cacheManager.GetUserPermissionCache().Remove(cacheKey);
        }

        public void HandleEvent(EntityChangedEventData<UserRole> eventData)
        {
            var cacheKey = eventData.Entity.UserId + "@" + (eventData.Entity.TenantId ?? 0);
            _cacheManager.GetUserPermissionCache().Remove(cacheKey);
        }

        public void HandleEvent(EntityDeletedEventData<AbpUserBase> eventData)
        {
            var cacheKey = eventData.Entity.Id + "@" + (eventData.Entity.TenantId ?? 0);
            _cacheManager.GetUserPermissionCache().Remove(cacheKey);
        }
    }
}