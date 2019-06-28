using Niue.Abp.Abp.Threading;
using Niue.Abp.Zero.Abp.Zero.Authorization.Roles;
using Niue.Abp.Zero.Abp.Zero.Authorization.Users;
using Niue.Abp.Zero.Abp.Zero.MultiTenancy;

namespace Niue.Abp.Zero.Abp.Zero.Authorization
{
    public static class AbpLogInManagerExtensions
    {
        public static AbpLoginResult<TTenant, TUser> Login<TTenant, TRole, TUser>(
            this AbpLogInManager<TTenant, TRole, TUser> logInManager, 
            string userNameOrEmailAddress, 
            string plainPassword, 
            string tenancyName = null, 
            bool shouldLockout = true)
                where TTenant : AbpTenant<TUser>
                where TRole : AbpRole<TUser>, new()
                where TUser : AbpUser<TUser>
        {
            return AsyncHelper.RunSync(
                () => logInManager.LoginAsync(
                    userNameOrEmailAddress,
                    plainPassword,
                    tenancyName,
                    shouldLockout
                )
            );
        }
    }
}
