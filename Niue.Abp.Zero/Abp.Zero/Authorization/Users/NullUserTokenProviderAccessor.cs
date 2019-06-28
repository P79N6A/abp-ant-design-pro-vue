using Microsoft.AspNet.Identity;
using Niue.Abp.Abp.Dependency;

namespace Niue.Abp.Zero.Abp.Zero.Authorization.Users
{
    public class NullUserTokenProviderAccessor : IUserTokenProviderAccessor, ISingletonDependency
    {
        public IUserTokenProvider<TUser, long> GetUserTokenProviderOrNull<TUser>() where TUser : AbpUser<TUser>
        {
            return null;
        }
    }
}