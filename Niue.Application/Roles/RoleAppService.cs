using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Niue.Abp.Abp.Authorization;
using Niue.Abp.Abp.AutoMapper.AutoMapper;
using Niue.Abp.Abp.Domain.Repositories;
using Niue.Abp.Zero.Abp.Zero.Authorization.Users;
using Niue.Application.BaseDto;
using Niue.Application.Roles.Dto;
using Niue.Core.Authorization.Roles;

namespace Niue.Application.Roles
{
    /* THIS IS JUST A SAMPLE. */
    public class RoleAppService : NiueAppServiceBase, IRoleAppService
    {
        private readonly RoleManager _roleManager;
        private readonly IPermissionManager _permissionManager;
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<UserRole, long> _userRoleRepository;

        public RoleAppService(RoleManager roleManager, IPermissionManager permissionManager, IRepository<Role> roleRepository, IRepository<UserRole, long> userRoleRepository)
        {
            _roleManager = roleManager;
            _permissionManager = permissionManager;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
        }

        public async Task UpdateRolePermissions(UpdateRolePermissionsInput input)
        {
            var role = await _roleManager.GetRoleByIdAsync(input.RoleId);
            var grantedPermissions = _permissionManager
                .GetAllPermissions()
                .Where(p => input.GrantedPermissionNames.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);
        }

        public async Task<ResultDto> GetAllRoles()
        {
            var roles = await _roleRepository.GetAllListAsync();
            if (AbpSession.UserId > 1)
            {
                roles = roles.FindAll(o => o.Id > 1);
            }
            return new ResultDto { Code = 0, Message = "获取成功！", Data = roles.MapTo<List<RoleDto>>() };
        }

        public async Task<ResultDto> GetRoles(GetRolesSearchInput searchInput)
        {
            var roles = await _roleRepository.GetAllListAsync();
            if (AbpSession.UserId > 1)
            {
                roles = roles.FindAll(o => o.Id > 2);
            }
            if (!string.IsNullOrWhiteSpace(searchInput.DisplayName))
            {
                roles = roles.Where(o => (!string.IsNullOrWhiteSpace(o.DisplayName) && o.DisplayName.Contains(searchInput.DisplayName))).ToList();
            }
            if (!string.IsNullOrWhiteSpace(searchInput.Name))
            {
                roles = roles.Where(o => (!string.IsNullOrWhiteSpace(o.Name) && o.Name.Contains(searchInput.Name))).ToList();
            }
            var roleDtos = roles.MapTo<List<RoleDto>>();
            return new ResultDto { Code = 0, Message = "获取成功！", Data = roleDtos };
        }

        public async Task<ResultDto> AddRole(EditRoleInput input)
        {
            if (input.IsDefault)
            {
                var defaultRole = await _roleRepository.FirstOrDefaultAsync(o => o.IsDefault);
                if (defaultRole != null)
                {
                    return new ResultDto { Code = 1, Message = "保存失败！已存在默认角色。", Data = null };
                }
            }
            var role = new Role();
            role.Name = input.Name;
            role.DisplayName = input.DisplayName;
            role.IsDefault = input.IsDefault;
            role.CreationTime = DateTime.Now;
            role.CreatorUserId = AbpSession.UserId;
            role.IsStatic = false;
            await _roleManager.CreateAsync(role);
            return new ResultDto { Code = 0, Message = "保存成功！", Data = null };
        }

        public async Task<ResultDto> EditRole(EditRoleInput input)
        {
            if (input.IsDefault)
            {
                var defaultRole = await _roleRepository.FirstOrDefaultAsync(o => o.IsDefault);
                if (defaultRole != null && defaultRole.Id != input.Id)
                {
                    return new ResultDto { Code = 1, Message = "保存失败！已存在默认角色。", Data = null };
                }
            }
            var role = await _roleRepository.FirstOrDefaultAsync(o => o.Id == input.Id);
            if (role == null)
            {
                return new ResultDto { Code = 1, Message = "保存失败！不存在该角色。", Data = null };
            }
            if (role.IsStatic)
            {
                return new ResultDto { Code = 1, Message = "保存失败！该角色为系统分配角色。", Data = null };
            }
            role.Name = input.Name;
            role.DisplayName = input.DisplayName;
            role.IsDefault = input.IsDefault;
            role.LastModificationTime = DateTime.Now;
            role.LastModifierUserId = AbpSession.UserId;
            await _roleManager.UpdateAsync(role);
            return new ResultDto { Code = 0, Message = "保存成功！", Data = null };
        }

        public async Task<ResultDto> DeleteRole(EditRoleInput input)
        {
            var role = await _roleRepository.FirstOrDefaultAsync(o => o.Id == input.Id);
            if (role == null)
            {
                return new ResultDto { Code = 1, Message = "保存失败！不存在该角色。", Data = null };
            }
            if (role.IsStatic)
            {
                return new ResultDto { Code = 1, Message = "保存失败！该角色为系统分配角色。", Data = null };
            }
            if (role.IsDefault)
            {
                return new ResultDto { Code = 1, Message = "保存失败！该角色为默认角色。", Data = null };
            }
            var queryUser = await _userRoleRepository.GetAllListAsync(m=>m.RoleId==input.Id);
            if (queryUser.Count > 0)
            {
                return new ResultDto { Code = 1, Message = "该角色下有用户，不能删除。", Data = null };
            }
            role.DeletionTime = DateTime.Now;
            role.DeleterUserId = AbpSession.UserId;
            await _roleManager.DeleteAsync(role);
            return new ResultDto { Code = 0, Message = "删除成功！", Data = null };
        }
    }
}