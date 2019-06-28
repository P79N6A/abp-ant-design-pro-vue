using Niue.Abp.Abp.Application.Services.Dto;
using Niue.Abp.Abp.AutoMapper.AutoMapper;
using Niue.Core.Authorization.Roles;

namespace Niue.Application.Roles.Dto
{
    [AutoMapFrom(typeof(Role))]
    public class RoleDto : EntityDto
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsDefault { get; set; }
        public bool IsStatic { get; set; }
        public bool IsChanged { get; set; }
    }
}
