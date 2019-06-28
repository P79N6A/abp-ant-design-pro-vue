using Niue.Abp.Abp.Application.Services.Dto;

namespace Niue.Application.Roles.Dto
{
    public class EditRoleInput : EntityDto
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsDefault { get; set; }
    }
}
