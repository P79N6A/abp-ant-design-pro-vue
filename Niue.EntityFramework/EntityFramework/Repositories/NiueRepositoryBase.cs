using Niue.Abp.Abp.Domain.Entities;
using Niue.Abp.Abp.EntityFramework.EntityFramework;
using Niue.Abp.Abp.EntityFramework.EntityFramework.Repositories;

namespace Niue.EntityFramework.EntityFramework.Repositories
{
    public abstract class NiueRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<NiueDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected NiueRepositoryBase(IDbContextProvider<NiueDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class NiueRepositoryBase<TEntity> : NiueRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected NiueRepositoryBase(IDbContextProvider<NiueDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
