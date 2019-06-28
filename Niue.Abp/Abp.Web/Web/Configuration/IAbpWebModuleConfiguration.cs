using Niue.Abp.Abp.Web.Web.Security.AntiForgery;

namespace Niue.Abp.Abp.Web.Web.Configuration
{
    public interface IAbpWebModuleConfiguration
    {
        IAbpAntiForgeryWebConfiguration AntiForgery { get; }

        IAbpWebLocalizationConfiguration Localization { get; }
    }
}