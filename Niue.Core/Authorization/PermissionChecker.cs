using Niue.Abp.Zero.Abp.Zero.Authorization;
using Niue.Core.Authorization.Roles;
using Niue.Core.MultiTenancy;
using Niue.Core.Users;

namespace Niue.Core.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
