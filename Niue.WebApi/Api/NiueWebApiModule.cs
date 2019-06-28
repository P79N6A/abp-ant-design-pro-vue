using System.Reflection;
using System.Web.Http;
using Niue.Abp.Abp.Application.Services;
using Niue.Abp.Abp.Modules;
using Niue.Abp.Abp.Web.Api.Configuration.Startup;
using Niue.Abp.Abp.Web.Api.WebApi;
using Niue.Application;

namespace Niue.WebApi.Api
{
    [DependsOn(typeof(AbpWebApiModule), typeof(NiueApplicationModule))]
    public class NiueWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(NiueApplicationModule).Assembly, "app")
                .Build();

            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));
        }
    }
}
