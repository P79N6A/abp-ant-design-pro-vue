using Niue.Abp.Abp.Application.Navigation;
using Niue.Abp.Abp.Collections;

namespace Niue.Abp.Abp.Configuration.Startup
{
    /// <summary>
    /// Used to configure navigation.
    /// </summary>
    public interface INavigationConfiguration
    {
        /// <summary>
        /// List of navigation providers.
        /// </summary>
        ITypeList<NavigationProvider> Providers { get; }
    }
}