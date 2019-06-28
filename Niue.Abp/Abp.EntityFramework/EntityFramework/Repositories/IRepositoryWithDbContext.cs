using System.Data.Entity;

namespace Niue.Abp.Abp.EntityFramework.EntityFramework.Repositories
{
    public interface IRepositoryWithDbContext
    {
        DbContext GetDbContext();
    }
}