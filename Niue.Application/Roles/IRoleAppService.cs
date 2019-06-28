using System.Collections.Generic;
using System.Threading.Tasks;
using Niue.Abp.Abp.Application.Services;
using Niue.Application.BaseDto;
using Niue.Application.Roles.Dto;

namespace Niue.Application.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
        Task<ResultDto> GetAllRoles();
        Task<ResultDto> GetRoles(GetRolesSearchInput searchInput);
        Task<ResultDto> AddRole(EditRoleInput input);
        Task<ResultDto> EditRole(EditRoleInput input);
        Task<ResultDto> DeleteRole(EditRoleInput input);
    }
}
