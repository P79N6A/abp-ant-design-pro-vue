using System.Collections.Generic;
using System.Threading.Tasks;
using Niue.Abp.Abp.Application.Services;
using Niue.Application.Routers.Dto;

namespace Niue.Application.Routers
{
    public interface IRouterAppService : IApplicationService
    {
        Task<List<RouterDto>> GetRouters();
    }
}
