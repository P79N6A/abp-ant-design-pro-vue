using Niue.Abp.Abp.Configuration.Startup;
using Niue.Abp.Abp.Web.Api.WebApi.Configuration;

namespace Niue.Abp.Abp.Web.Api.Configuration.Startup
{
    /// <summary>
    /// Defines extension methods to <see cref="IModuleConfigurations"/> to allow to configure Abp.Web.Api module.
    /// </summary>
    public static class AbpWebApiConfigurationExtensions
    {
        /// <summary>
        /// Used to configure Abp.Web.Api module.
        /// </summary>
        public static IAbpWebApiConfiguration AbpWebApi(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.Get<IAbpWebApiConfiguration>();
        }
    }
}