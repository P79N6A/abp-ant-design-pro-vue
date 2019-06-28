using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Niue.Abp.Abp.Domain.Repositories;
using Niue.Abp.Abp.Runtime.Session;
using Niue.Core.Entities.Cities;

namespace Niue.Core.Entities.Schools
{
    public class SchoolManager : ISchoolManager
    {
        public IAbpSession AbpSession { get; set; }
        private readonly IRepository<School, int> _schoolRepository;
        private readonly IRepository<City, int> _cityRepository;

        public SchoolManager(IRepository<School, int> schoolRepository, IRepository<City, int> cityRepository)
        {
            AbpSession = NullAbpSession.Instance;
            _schoolRepository = schoolRepository;
            _cityRepository = cityRepository;
        }

        public async Task<List<School>> FindAsync(Expression<Func<School, bool>> expression)
        {
            var schools = await _schoolRepository.GetAllListAsync();
            return schools.Where(expression.Compile()).OrderBy(o => o.UserId).ToList();
        }

        public async Task<School> FindByIdAsync(int id)
        {
            return await _schoolRepository.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<School> InsertAsync(School school)
        {
            var city = _cityRepository.FirstOrDefault(o => o.Id == school.City.Id);
            school.Code = city.AmapCityCode + city.SchoolSecurityCode.ToString().PadLeft(4, '0');
            city.SchoolSecurityCode = city.SchoolSecurityCode + 1;
            return await _schoolRepository.InsertAsync(school);
        }

        public async Task<School> UpdateAsync(School school)
        {
            return await _schoolRepository.UpdateAsync(school);
        }

        public async Task<bool> DeleteAsync(School school)
        {
            await _schoolRepository.DeleteAsync(school);
            return true;
        }
    }
}
