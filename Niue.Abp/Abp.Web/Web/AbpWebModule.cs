using System.Collections.Generic;
using System.Reflection;
using System.Web;
using Niue.Abp.Abp.Auditing;
using Niue.Abp.Abp.Collections.Extensions;
using Niue.Abp.Abp.Configuration.Startup;
using Niue.Abp.Abp.Dependency;
using Niue.Abp.Abp.Modules;
using Niue.Abp.Abp.Runtime.Session;
using Niue.Abp.Abp.Web.Auditing;
using Niue.Abp.Abp.Web.Common.Web;
using Niue.Abp.Abp.Web.Web.Configuration;
using Niue.Abp.Abp.Web.Web.MultiTenancy;
using Niue.Abp.Abp.Web.Web.Security.AntiForgery;
using Niue.Abp.Abp.Web.Web.Session;

namespace Niue.Abp.Abp.Web.Web
{
    /// <summary>
    /// This module is used to use ABP in ASP.NET web applications.
    /// </summary>
    [DependsOn(typeof(AbpWebCommonModule))]    
    public class AbpWebModule : AbpModule
    {
        /// <inheritdoc/>
        public override void PreInitialize()
        {
            IocManager.Register<IAbpAntiForgeryWebConfiguration, AbpAntiForgeryWebConfiguration>();
            IocManager.Register<IAbpWebLocalizationConfiguration, AbpWebLocalizationConfiguration>();
            IocManager.Register<IAbpWebModuleConfiguration, AbpWebModuleConfiguration>();
            
            Configuration.ReplaceService<IPrincipalAccessor, HttpContextPrincipalAccessor>(DependencyLifeStyle.Transient);
            Configuration.ReplaceService<IClientInfoProvider, WebClientInfoProvider>(DependencyLifeStyle.Transient);

            Configuration.MultiTenancy.Resolvers.Add<DomainTenantResolveContributor>();
            Configuration.MultiTenancy.Resolvers.Add<HttpHeaderTenantResolveContributor>();
            Configuration.MultiTenancy.Resolvers.Add<HttpCookieTenantResolveContributor>();

            AddIgnoredTypes();
        }

        /// <inheritdoc/>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());            
        }

        private void AddIgnoredTypes()
        {
            var ignoredTypes = new[]
            {
                typeof(HttpPostedFileBase),
                typeof(IEnumerable<HttpPostedFileBase>),
                typeof(HttpPostedFileWrapper),
                typeof(IEnumerable<HttpPostedFileWrapper>)
            };
            
            foreach (var ignoredType in ignoredTypes)
            {
                Configuration.Auditing.IgnoredTypes.AddIfNotContains(ignoredType);
                Configuration.Validation.IgnoredTypes.AddIfNotContains(ignoredType);
            }
        }
    }
}
