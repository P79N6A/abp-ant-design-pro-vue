using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Niue.Abp.Abp.Modules;
using Niue.Abp.Abp.Threading.BackgroundWorkers;
using Niue.Abp.Abp.Web.Mvc.Web.Mvc;
using Niue.Abp.Abp.Web.SignalR.Web.SignalR;
using Niue.Abp.Zero.Abp.Zero.Zero.Configuration;
using Niue.Application;
using Niue.EntityFramework;
using Niue.WebApi.Api;

namespace Niue.Web
{
    [DependsOn(
        typeof(NiueDataModule),
        typeof(NiueApplicationModule),
        typeof(NiueWebApiModule),
        typeof(AbpWebSignalRModule),
        //typeof(AbpHangfireModule), - ENABLE TO USE HANGFIRE INSTEAD OF DEFAULT JOB MANAGER
        typeof(AbpWebMvcModule))]
    public class NiueWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Enable database based localization
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<NiueNavigationProvider>();

            //Configure Hangfire - ENABLE TO USE HANGFIRE INSTEAD OF DEFAULT JOB MANAGER
            //Configuration.BackgroundJobs.UseHangfire(configuration =>
            //{
            //    configuration.GlobalConfiguration.UseSqlServerStorage("Default");
            //});
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public override void PostInitialize()
        {
            var workManager = IocManager.Resolve<IBackgroundWorkerManager>();
            //workManager.Add(IocManager.Resolve<ChangeBusinessPartyStateWorker>());
        }
    }
}
