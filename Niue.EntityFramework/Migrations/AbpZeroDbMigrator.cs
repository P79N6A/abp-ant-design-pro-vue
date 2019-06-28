using Niue.Abp.Abp.Dependency;
using Niue.Abp.Abp.Domain.Uow;
using Niue.Abp.Zero.Abp.Zero.EntityFramework.Zero.EntityFramework;
using Niue.Abp.Zero.Abp.Zero.MultiTenancy;
using Niue.EntityFramework.EntityFramework;

namespace Niue.EntityFramework.Migrations
{
    public class AbpZeroDbMigrator : AbpZeroDbMigrator<NiueDbContext, Configuration>
    {
        public AbpZeroDbMigrator(
            IUnitOfWorkManager unitOfWorkManager,
            IDbPerTenantConnectionStringResolver connectionStringResolver,
            IIocResolver iocResolver)
            : base(
                unitOfWorkManager,
                connectionStringResolver,
                iocResolver)
        {
        }
    }
}
