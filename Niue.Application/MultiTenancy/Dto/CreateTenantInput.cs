using System.ComponentModel.DataAnnotations;
using Niue.Abp.Abp.AutoMapper.AutoMapper;
using Niue.Abp.Zero.Abp.Zero.Authorization.Users;
using Niue.Abp.Zero.Abp.Zero.MultiTenancy;
using Niue.Core.MultiTenancy;

namespace Niue.Application.MultiTenancy.Dto
{
    [AutoMapTo(typeof(Tenant))]
    public class CreateTenantInput
    {
        [Required]
        [StringLength(AbpTenantBase.MaxTenancyNameLength)]
        [RegularExpression(Tenant.TenancyNameRegex)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(Tenant.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string AdminEmailAddress { get; set; }

        [MaxLength(AbpTenantBase.MaxConnectionStringLength)]
        public string ConnectionString { get; set; }
    }
}