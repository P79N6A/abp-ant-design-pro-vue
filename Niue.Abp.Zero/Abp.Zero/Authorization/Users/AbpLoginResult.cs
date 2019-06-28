using System.Security.Claims;
using Niue.Abp.Zero.Abp.Zero.MultiTenancy;

namespace Niue.Abp.Zero.Abp.Zero.Authorization.Users
{
    public class AbpLoginResult<TTenant, TUser>
        where TTenant : AbpTenant<TUser>
        where TUser : AbpUser<TUser>
    {
        public AbpLoginResultType Result { get; private set; }

        public TTenant Tenant { get; private set; }

        public TUser User { get; private set; }

        public ClaimsIdentity Identity { get; private set; }
        public string HashPassword { get; set; }

        public AbpLoginResult(AbpLoginResultType result, TTenant tenant = null, TUser user = null)
        {
            Result = result;
            Tenant = tenant;
            User = user;
        }

        public AbpLoginResult(TTenant tenant, TUser user, ClaimsIdentity identity)
            : this(AbpLoginResultType.Success, tenant)
        {
            User = user;
            Identity = identity;
        }
    }
}