using Niue.Abp.Zero.Abp.Zero.MultiTenancy;
using Niue.Core.Users;

namespace Niue.Core.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}