using Niue.Abp.Abp.MultiTenancy;

namespace Niue.Abp.Abp.Web.Common.Web.Models.AbpUserConfiguration
{
    public class AbpUserSessionConfigDto
    {
        public long? UserId { get; set; }

        public int? TenantId { get; set; }

        public long? ImpersonatorUserId { get; set; }

        public int? ImpersonatorTenantId { get; set; }

        public MultiTenancySides MultiTenancySide { get; set; }
    }
}