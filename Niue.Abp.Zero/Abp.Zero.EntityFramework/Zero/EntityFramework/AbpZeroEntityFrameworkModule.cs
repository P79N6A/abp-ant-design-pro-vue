using System.Reflection;
using Castle.MicroKernel.Registration;
using Niue.Abp.Abp.Domain.Uow;
using Niue.Abp.Abp.EntityFramework.EntityFramework;
using Niue.Abp.Abp.Modules;
using Niue.Abp.Zero.Abp.Zero.MultiTenancy;
using Niue.Abp.Zero.Abp.Zero.Zero;

namespace Niue.Abp.Zero.Abp.Zero.EntityFramework.Zero.EntityFramework
{
    /// <summary>
    /// Entity framework integration module for ASP.NET Boilerplate Zero.
    /// </summary>
    [DependsOn(typeof(AbpZeroCoreModule), typeof(AbpEntityFrameworkModule))]
    public class AbpZeroEntityFrameworkModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.ReplaceService(typeof(IConnectionStringResolver), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IConnectionStringResolver, IDbPerTenantConnectionStringResolver>()
                        .ImplementedBy<DbPerTenantConnectionStringResolver>()
                        .LifestyleTransient()
                    );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
