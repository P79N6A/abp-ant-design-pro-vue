using System.Threading.Tasks;
using Niue.Abp.Abp.Application.Services;
using Niue.Application.ApplicationServices.Cities.Dto;
using Niue.Application.BaseDto;

namespace Niue.Application.ApplicationServices.Cities
{
    public interface ICityAppService : IApplicationService
    {
        Task<ResultDto> GetCities(GetCitiesInput input);
        Task<ResultDto> AddCity(CityDto input);
        Task<ResultDto> EditCity(CityDto input);
        Task<ResultDto> DeleteCity(CityDto input);
        Task<ResultDto> GetAllCities();
    }
}
