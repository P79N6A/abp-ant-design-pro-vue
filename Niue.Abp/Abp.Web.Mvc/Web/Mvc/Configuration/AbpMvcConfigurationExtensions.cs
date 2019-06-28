using Niue.Abp.Abp.Configuration.Startup;

namespace Niue.Abp.Abp.Web.Mvc.Web.Mvc.Configuration
{
    /// <summary>
    /// Defines extension methods to <see cref="IModuleConfigurations"/> to allow to configure Abp.Web.Api module.
    /// </summary>
    public static class AbpMvcConfigurationExtensions
    {
        /// <summary>
        /// Used to configure Abp.Web.Api module.
        /// </summary>
        public static IAbpMvcConfiguration AbpMvc(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.Get<IAbpMvcConfiguration>();
        }
    }
}