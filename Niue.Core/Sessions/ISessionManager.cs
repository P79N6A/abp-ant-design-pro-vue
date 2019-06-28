using System.Threading.Tasks;
using Niue.Abp.Abp.Domain.Services;
using Niue.Core.Users;

namespace Niue.Core.Sessions
{
    public interface ISessionManager : IDomainService
    {
        Task<User> GetCurrentUser(long? currentUserId);
    }
}
