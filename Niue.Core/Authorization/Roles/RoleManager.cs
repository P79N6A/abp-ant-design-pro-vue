using Niue.Abp.Abp.Authorization;
using Niue.Abp.Abp.Domain.Uow;
using Niue.Abp.Abp.Runtime.Caching;
using Niue.Abp.Zero.Abp.Zero.Authorization.Roles;
using Niue.Abp.Zero.Abp.Zero.Zero.Configuration;
using Niue.Core.Users;

namespace Niue.Core.Authorization.Roles
{
    public class RoleManager : AbpRoleManager<Role, User>
    {
        public RoleManager(
            RoleStore store,
            IPermissionManager permissionManager,
            IRoleManagementConfig roleManagementConfig,
            ICacheManager cacheManager,
            IUnitOfWorkManager unitOfWorkManager)
            : base(
                store,
                permissionManager,
                roleManagementConfig,
                cacheManager,
                unitOfWorkManager)
        {
        }
    }
}