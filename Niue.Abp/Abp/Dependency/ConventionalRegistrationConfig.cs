using Castle.DynamicProxy;
using Niue.Abp.Abp.Configuration;

namespace Niue.Abp.Abp.Dependency
{
    /// <summary>
    /// This class is used to pass configuration/options while registering classes in conventional way.
    /// </summary>
    public class ConventionalRegistrationConfig : DictionaryBasedConfig
    {
        /// <summary>
        /// Install all <see cref="IInterceptor"/> implementations automatically or not.
        /// Default: true. 
        /// </summary>
        public bool InstallInstallers { get; set; }

        /// <summary>
        /// Creates a new <see cref="ConventionalRegistrationConfig"/> object.
        /// </summary>
        public ConventionalRegistrationConfig()
        {
            InstallInstallers = true;
        }
    }
}