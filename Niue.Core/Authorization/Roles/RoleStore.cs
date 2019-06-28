using Niue.Abp.Abp.Domain.Repositories;
using Niue.Abp.Zero.Abp.Zero.Authorization.Roles;
using Niue.Abp.Zero.Abp.Zero.Authorization.Users;
using Niue.Core.Users;

namespace Niue.Core.Authorization.Roles
{
    public class RoleStore : AbpRoleStore<Role, User>
    {
        public RoleStore(
            IRepository<Role> roleRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<RolePermissionSetting, long> rolePermissionSettingRepository)
            : base(
                roleRepository,
                userRoleRepository,
                rolePermissionSettingRepository)
        {
        }
    }
}