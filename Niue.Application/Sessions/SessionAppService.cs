using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Niue.Abp.Abp.Auditing;
using Niue.Abp.Abp.Authorization;
using Niue.Abp.Abp.Domain.Repositories;
using Niue.Abp.Abp.UI;
using Niue.Abp.Zero.Abp.Zero.Authorization.Users;
using Niue.Application.Sessions.Dto;
using Niue.Core.Authorization.RolePermissions;
using Niue.Core.Authorization.Roles;
using Niue.Core.Sessions;

namespace Niue.Application.Sessions
{
    [AbpAuthorize]
    public class SessionAppService : NiueAppServiceBase, ISessionAppService
    {
        private readonly ISessionManager _sessionManager;
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<UserRole, long> _userRoleRepository;
        private readonly IRolePermissionManager _rolePermissionManager;

        public SessionAppService(ISessionManager sessionManager, IRepository<Role> roleRepository, IRepository<UserRole, long> userRoleRepository, IRolePermissionManager rolePermissionManager)
        {
            _sessionManager = sessionManager;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _rolePermissionManager = rolePermissionManager;
        }

        [DisableAuditing]
        public async Task<UserInfoDto> GetInfo()
        {
            var currentUser = await _sessionManager.GetCurrentUser(AbpSession.UserId);
            if (currentUser == null)
            {
                throw new UserFriendlyException("当前用户会话失效，请重新登录。");
            }
            var userInfoDto = new UserInfoDto();
            userInfoDto.Id = currentUser.Id;
            userInfoDto.Name = currentUser.Name;
            userInfoDto.Username = currentUser.UserName;
            userInfoDto.Avatar = "\\Upload\\User\\Avatar\\" + currentUser.Id + ".jpg";
            userInfoDto.Status = currentUser.IsActive ? 1 : 0;
            userInfoDto.UserType = currentUser.UserType;
            userInfoDto.Telephone = currentUser.PhoneNumber;
            userInfoDto.RoleId = 0;
            userInfoDto.Role = new UserInfoRoleDto();
            userInfoDto.Role.Permissions = new List<UserInfoRolePermissionDto>();
            var userRole = await _userRoleRepository.FirstOrDefaultAsync(o => o.UserId == currentUser.Id);
            if (userRole == null)
            {
                return userInfoDto;
            }
            userInfoDto.RoleId = userRole.RoleId;
            var role = await _roleRepository.FirstOrDefaultAsync(o => o.Id == userRole.RoleId);
            if (role == null)
            {
                return userInfoDto;
            }
            userInfoDto.Role.Id = role.Id;
            userInfoDto.Role.Name = role.Name;
            userInfoDto.Role.Describe = role.DisplayName;
            userInfoDto.Role.Status = 1;
            var rolePermissions = await _rolePermissionManager.GetRolePermissionsByRoleIdAsync(role.Id);
            if (rolePermissions.Count == 0)
            {
                return userInfoDto;
            }
            foreach (var rolePermission in rolePermissions)
            {
                var rolePermissionDto = new UserInfoRolePermissionDto();
                rolePermissionDto.Id = rolePermission.Id;
                rolePermissionDto.RoleId = rolePermission.RoleId;
                rolePermissionDto.PermissionId = rolePermission.Router.Key;
                rolePermissionDto.PermissionName = rolePermission.Router.Name;
                rolePermissionDto.Actions = rolePermission.Actions;
                rolePermissionDto.ActionEntitySet =
                    JsonConvert.DeserializeObject<List<UserInfoActionEntitySetDto>>(rolePermission.Actions);
                userInfoDto.Role.Permissions.Add(rolePermissionDto);
            }
            return userInfoDto;
        }
    }
}