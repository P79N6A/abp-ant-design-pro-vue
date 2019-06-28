namespace Niue.Abp.Abp.Web.Common.Web.Models.AbpUserConfiguration
{
    public class AbpUserTimeZoneConfigDto
    {
        public AbpUserWindowsTimeZoneConfigDto Windows { get; set; }

        public AbpUserIanaTimeZoneConfigDto Iana { get; set; }
    }
}