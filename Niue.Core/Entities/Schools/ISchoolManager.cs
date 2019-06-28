using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Niue.Abp.Abp.Domain.Services;

namespace Niue.Core.Entities.Schools
{
    public interface ISchoolManager : IDomainService
    {
        Task<List<School>> FindAsync(Expression<Func<School, bool>> expression);
        Task<School> FindByIdAsync(int id);
        Task<School> InsertAsync(School school);
        Task<School> UpdateAsync(School school);
        Task<bool> DeleteAsync(School school);
    }
}
