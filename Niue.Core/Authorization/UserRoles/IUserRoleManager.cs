using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Niue.Abp.Abp.Domain.Services;
using Niue.Abp.Zero.Abp.Zero.Authorization.Users;

namespace Niue.Core.Authorization.UserRoles
{
    public interface IUserRoleManager : IDomainService
    {
        Task<List<UserRole>> GetUserRolesAsync(Expression<Func<UserRole, bool>> expression);
        Task<UserRole> GetUserRoleByIdAsync(long id);
        Task<UserRole> InsertUserRoleAsync(UserRole userRole);
        Task<UserRole> UpdateUserRoleAsync(UserRole userRole);
        Task<bool> DeleteUserRoleAsync(UserRole userRole);
    }
}
