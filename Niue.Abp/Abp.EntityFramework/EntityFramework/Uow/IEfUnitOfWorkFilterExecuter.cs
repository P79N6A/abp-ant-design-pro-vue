using System.Data.Entity;
using Niue.Abp.Abp.Domain.Uow;

namespace Niue.Abp.Abp.EntityFramework.EntityFramework.Uow
{
    public interface IEfUnitOfWorkFilterExecuter : IUnitOfWorkFilterExecuter
    {
        void ApplyCurrentFilters(IUnitOfWork unitOfWork, DbContext dbContext);
    }
}