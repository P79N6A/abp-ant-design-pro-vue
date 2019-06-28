using System.Threading.Tasks;
using Niue.Abp.Abp.Application.Services;
using Niue.Application.BaseDto;
using Niue.Application.Users.Dto;

namespace Niue.Application.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task<PaginationDto<UserDto>> GetUsers(GetUsersInput input);
        Task<ResultDto> AddUser(UserDto input);
        Task<ResultDto> EditUser(UserDto input);
        Task<ResultDto> ActiveUser(UserDto input);
        Task<ResultDto> DeleteUser(UserDto input);
    }
}