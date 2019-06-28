using System.Threading.Tasks;
using Niue.Abp.Abp.Application.Services;
using Niue.Application.Sessions.Dto;

namespace Niue.Application.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<UserInfoDto> GetInfo();
    }
}
