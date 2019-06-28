namespace Niue.Abp.Abp.Web.Web.Configuration
{
    public interface IAbpWebLocalizationConfiguration
    {
        /// <summary>
        /// Default: "Abp.Localization.CultureName".
        /// </summary>
        string CookieName { get; set; }
    }
}