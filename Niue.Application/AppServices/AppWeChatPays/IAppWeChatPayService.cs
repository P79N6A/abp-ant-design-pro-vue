using System.Threading.Tasks;
using Niue.Abp.Abp.Application.Services;
using Niue.Application.AppServices.AppWeChatPays.Dto;
using Niue.Application.BaseDto;

namespace Niue.Application.AppServices.AppWeChatPays
{
    public interface IAppWeChatPayService : IApplicationService
    {
        Task<ResultDto> GetPayInfo(GetPayInfoInput input);
        Task<ResultDto> PayNotify(PayNotifyInput input);
    }
}
