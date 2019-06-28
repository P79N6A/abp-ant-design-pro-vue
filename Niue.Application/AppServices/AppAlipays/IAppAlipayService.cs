using System.Threading.Tasks;
using Niue.Abp.Abp.Application.Services;
using Niue.Application.AppServices.AppAlipays.Dto;
using Niue.Application.BaseDto;

namespace Niue.Application.AppServices.AppAlipays
{
    public interface IAppAlipayService : IApplicationService
    {
        Task<ResultDto> GetPayInfo(GetPayInfoInput input);
        Task<ResultDto> PayNotify(PayNotifyInput input);
        Task<ResultDto> TestLive(TestLiveInput input);
    }
}
