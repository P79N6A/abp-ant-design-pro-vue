using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Niue.Abp.Abp.Domain.Repositories;
using Niue.Abp.Abp.Runtime.Session;

namespace Niue.Core.Authorization.RolePermissions
{
    public class RolePermissionManager : IRolePermissionManager
    {
        private IAbpSession AbpSession { get; set; }
        private readonly IRepository<RolePermission, long> _rolePermissionRepository;

        public RolePermissionManager(IRepository<RolePermission, long> rolePermissionRepository)
        {
            AbpSession = NullAbpSession.Instance;
            _rolePermissionRepository = rolePermissionRepository;
        }

        public async Task<List<RolePermission>> GetRolePermissionsAsync(Expression<Func<RolePermission, bool>> expression)
        {
            var rolePermissions = await _rolePermissionRepository.GetAllListAsync();
            return rolePermissions.Where(expression.Compile()).OrderBy(o => o.RoleId).ThenBy(o => o.Router.Key).ToList();
        }

        public async Task<List<RolePermission>> GetRolePermissionsByRoleIdAsync(int roleId)
        {
            var rolePermissions = await _rolePermissionRepository.GetAllListAsync(o => o.RoleId == roleId);
            return rolePermissions.OrderBy(o => o.Router.Key).ToList();
        }
    }
}
