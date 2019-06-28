using Microsoft.AspNet.Identity;

namespace Niue.Abp.Zero.Abp.Zero.Authorization.Users
{
    public interface IUserTokenProviderAccessor
    {
        IUserTokenProvider<TUser, long> GetUserTokenProviderOrNull<TUser>() 
            where TUser : AbpUser<TUser>;
    }
}