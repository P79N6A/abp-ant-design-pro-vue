using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Niue.Abp.Abp.Domain.Repositories;
using Niue.Abp.Abp.Runtime.Session;
using Niue.Abp.Zero.Abp.Zero.Authorization.Users;

namespace Niue.Core.Authorization.UserRoles
{
    public class UserRoleManager : IUserRoleManager
    {
        private readonly IRepository<UserRole, long> _userRoleRepository;
        private IAbpSession AbpSession { get; set; }

        public UserRoleManager(IRepository<UserRole, long> userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
            AbpSession = NullAbpSession.Instance;
        }

        public async Task<List<UserRole>> GetUserRolesAsync(Expression<Func<UserRole, bool>> expression)
        {
            var userRoles = await _userRoleRepository.GetAllListAsync();
            return userRoles.Where(expression.Compile()).OrderBy(o => o.UserId).ToList();
        }

        public async Task<UserRole> GetUserRoleByIdAsync(long id)
        {
            return await _userRoleRepository.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<UserRole> InsertUserRoleAsync(UserRole userRole)
        {
            userRole.CreatorUserId = AbpSession.UserId;
            userRole.CreationTime = DateTime.Now;
            return await _userRoleRepository.InsertAsync(userRole);
        }

        public async Task<UserRole> UpdateUserRoleAsync(UserRole userRole)
        {
            return await _userRoleRepository.UpdateAsync(userRole);
        }

        public async Task<bool> DeleteUserRoleAsync(UserRole userRole)
        {
            await _userRoleRepository.DeleteAsync(userRole);
            return true;
        }
    }
}