using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Niue.Abp.Abp.Domain.Repositories;
using Niue.Abp.Abp.Runtime.Session;

namespace Niue.Core.Entities.Cities
{
    public class CityManager : ICityManager
    {
        public IAbpSession AbpSession { get; set; }
        private readonly IRepository<City, int> _cityRepository;

        public CityManager(IRepository<City, int> cityRepository)
        {
            AbpSession = NullAbpSession.Instance;
            _cityRepository = cityRepository;
        }

        public async Task<List<City>> FindAsync(Expression<Func<City, bool>> expression)
        {
            var cities = await _cityRepository.GetAllListAsync();
            return cities.Where(expression.Compile()).OrderBy(o => o.Province).ThenBy(o => o.Name).ToList();
        }

        public async Task<City> FindByIdAsync(int id)
        {
            return await _cityRepository.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<City> InsertAsync(City city)
        {
            return await _cityRepository.InsertAsync(city);
        }

        public async Task<City> UpdateAsync(City city)
        {
            return await _cityRepository.UpdateAsync(city);
        }

        public async Task<bool> DeleteAsync(City city)
        {
            await _cityRepository.DeleteAsync(city);
            return true;
        }
    }
}
