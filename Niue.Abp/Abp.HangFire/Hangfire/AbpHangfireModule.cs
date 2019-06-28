using System.Reflection;
using Hangfire;
using Niue.Abp.Abp.HangFire.Hangfire.Configuration;
using Niue.Abp.Abp.Modules;

namespace Niue.Abp.Abp.HangFire.Hangfire
{
    [DependsOn(typeof(AbpKernelModule))]
    public class AbpHangfireModule : AbpModule
    {
        public override void PreInitialize()
        {
            IocManager.Register<IAbpHangfireConfiguration, AbpHangfireConfiguration>();
            
            Configuration.Modules
                .AbpHangfire()
                .GlobalConfiguration
                .UseActivator(new HangfireIocJobActivator(IocManager));
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
