using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Niue.Abp.Abp.Application.Services;
using Niue.Abp.Abp.Runtime.Session;
using Niue.Abp.Zero.Abp.Zero.IdentityFramework;
using Niue.Core;
using Niue.Core.Authorization.Roles;
using Niue.Core.MultiTenancy;
using Niue.Core.Users;

namespace Niue.Application
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class NiueAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        public RoleManager RoleManager { get; set; }
        public  string serverPath = ConfigurationManager.AppSettings["ServerPath"];
        protected NiueAppServiceBase()
        {
            LocalizationSourceName = NiueConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected async Task<Role> GetCurrentRole(long id)
        {
            var userRoles = await UserManager.GetRolesAsync(id);
            if (userRoles.Count == 0)
            {
                return null;
            }
            foreach (var role in RoleManager.Roles)
            {
                if (role.Name == userRoles[0])
                {
                    return role;
                }
            }
            return null;
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}