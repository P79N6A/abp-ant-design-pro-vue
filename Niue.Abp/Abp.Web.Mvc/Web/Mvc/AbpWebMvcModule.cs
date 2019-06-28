using System;
using System.Reflection;
using System.Web.Hosting;
using System.Web.Mvc;
using Niue.Abp.Abp.Configuration.Startup;
using Niue.Abp.Abp.Modules;
using Niue.Abp.Abp.Web.Common.Web.Security.AntiForgery;
using Niue.Abp.Abp.Web.Mvc.Web.Mvc.Auditing;
using Niue.Abp.Abp.Web.Mvc.Web.Mvc.Authorization;
using Niue.Abp.Abp.Web.Mvc.Web.Mvc.Configuration;
using Niue.Abp.Abp.Web.Mvc.Web.Mvc.Controllers;
using Niue.Abp.Abp.Web.Mvc.Web.Mvc.ModelBinding.Binders;
using Niue.Abp.Abp.Web.Mvc.Web.Mvc.Resources.Embedded;
using Niue.Abp.Abp.Web.Mvc.Web.Mvc.Security.AntiForgery;
using Niue.Abp.Abp.Web.Mvc.Web.Mvc.Uow;
using Niue.Abp.Abp.Web.Mvc.Web.Mvc.Validation;
using Niue.Abp.Abp.Web.Web;

namespace Niue.Abp.Abp.Web.Mvc.Web.Mvc
{
    /// <summary>
    /// This module is used to build ASP.NET MVC web sites using Abp.
    /// </summary>
    [DependsOn(typeof(AbpWebModule))]
    public class AbpWebMvcModule : AbpModule
    {
        /// <inheritdoc/>
        public override void PreInitialize()
        {
            IocManager.AddConventionalRegistrar(new ControllerConventionalRegistrar());

            IocManager.Register<IAbpMvcConfiguration, AbpMvcConfiguration>();

            Configuration.ReplaceService<IAbpAntiForgeryManager, AbpMvcAntiForgeryManager>();
        }

        /// <inheritdoc/>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(IocManager));
            HostingEnvironment.RegisterVirtualPathProvider(IocManager.Resolve<EmbeddedResourceVirtualPathProvider>());
        }

        /// <inheritdoc/>
        public override void PostInitialize()
        {
            GlobalFilters.Filters.Add(IocManager.Resolve<AbpMvcAuthorizeFilter>());
            GlobalFilters.Filters.Add(IocManager.Resolve<AbpAntiForgeryMvcFilter>());
            GlobalFilters.Filters.Add(IocManager.Resolve<AbpMvcAuditFilter>());
            GlobalFilters.Filters.Add(IocManager.Resolve<AbpMvcValidationFilter>());
            GlobalFilters.Filters.Add(IocManager.Resolve<AbpMvcUowFilter>());

            var abpMvcDateTimeBinder = new AbpMvcDateTimeBinder();
            ModelBinders.Binders.Add(typeof(DateTime), abpMvcDateTimeBinder);
            ModelBinders.Binders.Add(typeof(DateTime?), abpMvcDateTimeBinder);
        }
    }
}
