using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Niue.Abp.Abp.Domain.Services;

namespace Niue.Core.Entities.Cities
{
    public interface ICityManager : IDomainService
    {
        Task<List<City>> FindAsync(Expression<Func<City, bool>> expression);
        Task<City> FindByIdAsync(int id);
        Task<City> InsertAsync(City city);
        Task<City> UpdateAsync(City city);
        Task<bool> DeleteAsync(City city);
    }
}
