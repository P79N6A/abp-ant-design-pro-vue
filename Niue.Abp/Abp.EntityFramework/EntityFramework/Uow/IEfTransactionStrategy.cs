using System.Data.Entity;
using Niue.Abp.Abp.Dependency;
using Niue.Abp.Abp.Domain.Uow;

namespace Niue.Abp.Abp.EntityFramework.EntityFramework.Uow
{
    public interface IEfTransactionStrategy
    {
        void InitOptions(UnitOfWorkOptions options);

        DbContext CreateDbContext<TDbContext>(string connectionString, IDbContextResolver dbContextResolver)
            where TDbContext : DbContext;

        void Commit();

        void Dispose(IIocResolver iocResolver);
    }
}