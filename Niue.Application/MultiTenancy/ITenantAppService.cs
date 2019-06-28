using System.Threading.Tasks;
using Niue.Abp.Abp.Application.Services;
using Niue.Abp.Abp.Application.Services.Dto;
using Niue.Application.MultiTenancy.Dto;

namespace Niue.Application.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultDto<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
