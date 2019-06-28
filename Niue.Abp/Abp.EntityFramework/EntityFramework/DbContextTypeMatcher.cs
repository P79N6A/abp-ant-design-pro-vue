using Niue.Abp.Abp.Domain.Uow;
using Niue.Abp.Abp.EntityFramework.Common;

namespace Niue.Abp.Abp.EntityFramework.EntityFramework
{
    public class DbContextTypeMatcher : DbContextTypeMatcher<AbpDbContext>
    {
        public DbContextTypeMatcher(ICurrentUnitOfWorkProvider currentUnitOfWorkProvider) 
            : base(currentUnitOfWorkProvider)
        {
        }
    }
}