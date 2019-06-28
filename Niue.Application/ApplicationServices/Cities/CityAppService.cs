using System.Collections.Generic;
using System.Threading.Tasks;
using Niue.Abp.Abp.AutoMapper.AutoMapper;
using Niue.Application.ApplicationServices.Cities.Dto;
using Niue.Application.BaseDto;
using Niue.Common;
using Niue.Core.Entities.Cities;

namespace Niue.Application.ApplicationServices.Cities
{
    public class CityAppService : NiueAppServiceBase, ICityAppService
    {
        private readonly ICityManager _cityManager;

        public CityAppService(ICityManager cityManager)
        {
            _cityManager = cityManager;
        }

        public async Task<ResultDto> GetCities(GetCitiesInput input)
        {
            var expression = LambdaExtensions.CreateExpression<City>();
            if (!string.IsNullOrWhiteSpace(input.Name))
            {
                var andExpression = LambdaExtensions.CreateExpression<City>(o => o.Name.Contains(input.Name));
                expression = LambdaExtensions.AdditionalExpression(expression, andExpression);
            }
            var cities = await _cityManager.FindAsync(expression);
            return new ResultDto {Code = 0, Message = "获取成功！", Data = cities.MapTo<CityDto>()};
        }

        public async Task<ResultDto> AddCity(CityDto input)
        {
   //         var city = new City();
			//city.Name = input.Name;
			//city.SpellAll = input.SpellAll;
			//city.SpellShort = input.SpellShort;
			//city.Sort = input.Sort;
			//city.IsHot = input.IsHot;
			//city.Province_Id = input.Province_Id;
	
   //         await _cityManager.InsertAsync(city);
            return new ResultDto { Code = 0, Message = "保存成功！" };
        }

        public async Task<ResultDto> EditCity(CityDto input)
        {
   //         var city = await _cityManager.FindByIdAsync(input.Id);
   //         if (city == null)
   //         {
   //             return new ResultDto { Code = 1, Message = "保存失败！Id错误。" };
   //         }
			//city.Name = input.Name;
			//city.SpellAll = input.SpellAll;
			//city.SpellShort = input.SpellShort;
			//city.Sort = input.Sort;
			//city.IsHot = input.IsHot;
			//city.Province_Id = input.Province_Id;
	
   //         await _cityManager.UpdateAsync(city);
            return new ResultDto { Code = 0, Message = "保存成功！" };
        }

        public async Task<ResultDto> DeleteCity(CityDto input)
        {
            //var city = await _cityManager.FindByIdAsync(input.Id);
            //if (city == null)
            //{
            //    return new ResultDto { Code = 1, Message = "删除失败！Id错误。" };
            //}
            //await _cityManager.DeleteAsync(city);
            return new ResultDto { Code = 0, Message = "删除成功！" };
        }

        public async Task<ResultDto> GetAllCities()
        {
            var cities = await _cityManager.FindAsync(o => o.Province != null && o.Province.Id > 0);
            return new ResultDto { Code = 0, Message = "获取成功！", Data = cities.MapTo<List<CityDto>>() };
        }
    }
}
