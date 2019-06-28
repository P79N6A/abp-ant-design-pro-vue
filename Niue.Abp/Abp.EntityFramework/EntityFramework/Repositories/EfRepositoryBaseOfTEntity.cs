using System.Data.Entity;
using Niue.Abp.Abp.Domain.Entities;
using Niue.Abp.Abp.Domain.Repositories;

namespace Niue.Abp.Abp.EntityFramework.EntityFramework.Repositories
{
    public class EfRepositoryBase<TDbContext, TEntity> : EfRepositoryBase<TDbContext, TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
        where TDbContext : DbContext
    {
        public EfRepositoryBase(IDbContextProvider<TDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}