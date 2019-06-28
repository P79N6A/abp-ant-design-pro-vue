using System.Reflection;
using Niue.Abp.Abp.Localization.Dictionaries;
using Niue.Abp.Abp.Localization.Dictionaries.Xml;
using Niue.Abp.Abp.Modules;
using Niue.Abp.Abp.Web.Common.Configuration.Startup;
using Niue.Abp.Abp.Web.Common.Web.Api.ProxyScripting.Configuration;
using Niue.Abp.Abp.Web.Common.Web.Api.ProxyScripting.Generators.JQuery;
using Niue.Abp.Abp.Web.Common.Web.Configuration;
using Niue.Abp.Abp.Web.Common.Web.MultiTenancy;
using Niue.Abp.Abp.Web.Common.Web.Security.AntiForgery;

namespace Niue.Abp.Abp.Web.Common.Web
{
    /// <summary>
    /// This module is used to use ABP in ASP.NET web applications.
    /// </summary>
    [DependsOn(typeof(AbpKernelModule))]    
    public class AbpWebCommonModule : AbpModule
    {
        /// <inheritdoc/>
        public override void PreInitialize()
        {
            IocManager.Register<IWebMultiTenancyConfiguration, WebMultiTenancyConfiguration>();
            IocManager.Register<IApiProxyScriptingConfiguration, ApiProxyScriptingConfiguration>();
            IocManager.Register<IAbpAntiForgeryConfiguration, AbpAntiForgeryConfiguration>();
            IocManager.Register<IWebEmbeddedResourcesConfiguration, WebEmbeddedResourcesConfiguration>();
            IocManager.Register<IAbpWebCommonModuleConfiguration, AbpWebCommonModuleConfiguration>();

            Configuration.Modules.AbpWebCommon().ApiProxyScripting.Generators[JQueryProxyScriptGenerator.Name] = typeof(JQueryProxyScriptGenerator);

            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    AbpWebConsts.LocalizaionSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(), "Abp.Web.Common.Web.Localization.AbpWebXmlSource"
                        )));
        }

        /// <inheritdoc/>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());            
        }
    }
}
