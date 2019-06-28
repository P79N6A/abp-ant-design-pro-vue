using Niue.Abp.Abp.Web.Web.Security.AntiForgery;

namespace Niue.Abp.Abp.Web.Web.Configuration
{
    public class AbpWebModuleConfiguration : IAbpWebModuleConfiguration
    {
        public IAbpAntiForgeryWebConfiguration AntiForgery { get; }
        public IAbpWebLocalizationConfiguration Localization { get; }

        public AbpWebModuleConfiguration(
            IAbpAntiForgeryWebConfiguration antiForgery, 
            IAbpWebLocalizationConfiguration localization)
        {
            AntiForgery = antiForgery;
            Localization = localization;
        }
    }
}