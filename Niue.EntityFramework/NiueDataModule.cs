using System.Data.Entity;
using System.Reflection;
using Niue.Abp.Abp.Modules;
using Niue.Abp.Zero.Abp.Zero.EntityFramework.Zero.EntityFramework;
using Niue.Core;
using Niue.EntityFramework.EntityFramework;

namespace Niue.EntityFramework
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(NiueCoreModule))]
    public class NiueDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<NiueDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
