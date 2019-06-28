using Niue.Abp.Abp.Application.Navigation;
using Niue.Abp.Abp.Collections;

namespace Niue.Abp.Abp.Configuration.Startup
{
    internal class NavigationConfiguration : INavigationConfiguration
    {
        public ITypeList<NavigationProvider> Providers { get; private set; }

        public NavigationConfiguration()
        {
            Providers = new TypeList<NavigationProvider>();
        }
    }
}