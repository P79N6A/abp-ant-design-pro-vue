using Niue.Abp.Abp.Application.Services.Dto;
using Niue.Abp.Abp.AutoMapper.AutoMapper;
using Niue.Core.MultiTenancy;

namespace Niue.Application.MultiTenancy.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantListDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}