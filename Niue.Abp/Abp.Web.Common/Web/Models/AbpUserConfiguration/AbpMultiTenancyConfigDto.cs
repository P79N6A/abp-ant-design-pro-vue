namespace Niue.Abp.Abp.Web.Common.Web.Models.AbpUserConfiguration
{
    public class AbpMultiTenancyConfigDto
    {
        public bool IsEnabled { get; set; }

        public AbpMultiTenancySidesConfigDto Sides { get; private set; }

        public AbpMultiTenancyConfigDto()
        {
            Sides = new AbpMultiTenancySidesConfigDto();
        }
    }
}