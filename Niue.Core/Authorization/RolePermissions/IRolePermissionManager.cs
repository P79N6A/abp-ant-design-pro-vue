using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Niue.Abp.Abp.Domain.Services;

namespace Niue.Core.Authorization.RolePermissions
{
    public interface IRolePermissionManager : IDomainService
    {
        Task<List<RolePermission>> GetRolePermissionsAsync(Expression<Func<RolePermission, bool>> expression);
        Task<List<RolePermission>> GetRolePermissionsByRoleIdAsync(int roleId);
    }
}
