using System.Data.Entity;

namespace Niue.Abp.Abp.EntityFramework.EntityFramework.Uow
{
    public class ActiveDbContextInfo
    {
        public DbContext DbContext { get; }

        public ActiveDbContextInfo(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}