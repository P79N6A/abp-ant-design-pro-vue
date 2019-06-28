using Niue.Abp.Abp.Configuration.Startup;
using Niue.Abp.Abp.Web.Web.Configuration;

namespace Niue.Abp.Abp.Web.Configuration.Startup
{
    /// <summary>
    /// Defines extension methods to <see cref="IModuleConfigurations"/> to allow to configure ABP Web module.
    /// </summary>
    public static class AbpWebConfigurationExtensions
    {
        /// <summary>
        /// Used to configure ABP Web module.
        /// </summary>
        public static IAbpWebModuleConfiguration AbpWeb(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.Get<IAbpWebModuleConfiguration>();
        }
    }
}