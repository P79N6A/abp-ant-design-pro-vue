using Niue.Abp.Abp.Authorization;
using Niue.Abp.Abp.Configuration;
using Niue.Abp.Abp.Domain.Repositories;
using Niue.Abp.Abp.Domain.Uow;
using Niue.Abp.Abp.Localization;
using Niue.Abp.Abp.Runtime.Caching;
using Niue.Abp.Zero.Abp.Zero.Authorization.Users;
using Niue.Abp.Zero.Abp.Zero.IdentityFramework;
using Niue.Abp.Zero.Abp.Zero.Organizations;
using Niue.Core.Authorization.Roles;

namespace Niue.Core.Users
{
    public class UserManager : AbpUserManager<Role, User>
    {
        public UserManager(
            UserStore userStore,
            RoleManager roleManager,
            IPermissionManager permissionManager,
            IUnitOfWorkManager unitOfWorkManager,
            ICacheManager cacheManager,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            IOrganizationUnitSettings organizationUnitSettings,
            ILocalizationManager localizationManager,
            ISettingManager settingManager,
            IdentityEmailMessageService emailService,
            IUserTokenProviderAccessor userTokenProviderAccessor)
            : base(
                  userStore,
                  roleManager,
                  permissionManager,
                  unitOfWorkManager,
                  cacheManager,
                  organizationUnitRepository,
                  userOrganizationUnitRepository,
                  organizationUnitSettings,
                  localizationManager,
                  emailService,
                  settingManager,
                  userTokenProviderAccessor)
        {
        }
    }
}