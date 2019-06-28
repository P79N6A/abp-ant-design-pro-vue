using System.Threading.Tasks;
using Niue.Abp.Abp.Domain.Repositories;
using Niue.Core.Users;

namespace Niue.Core.Sessions
{
    public class SessionManager : ISessionManager
    {
        private readonly IRepository<User, long> _userRepository;

        public SessionManager(IRepository<User, long> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetCurrentUser(long? currentUserId)
        {
            if (currentUserId == null)
            {
                return null;
            }
            var currentUser = await _userRepository.FirstOrDefaultAsync(o => o.Id == currentUserId.Value && o.IsActive);
            return currentUser;
        }
    }
}
