using System.Data.Entity.Migrations;
using EntityFramework.DynamicFilters;
using Niue.Abp.Zero.Abp.Zero.EntityFramework.Zero.EntityFramework;
using Niue.Abp.Zero.Abp.Zero.MultiTenancy;
using Niue.EntityFramework.EntityFramework;
using Niue.EntityFramework.Migrations.SeedData;

namespace Niue.EntityFramework.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<NiueDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Niue";
        }

        protected override void Seed(NiueDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            //TODO: �˴��������Ͳ�������ΪNullable�����ް취�����


            context.SaveChanges();
        }
    }
}
