using System.Threading.Tasks;
using System.Web.Http;
using Niue.Abp.Abp.Web.Api.WebApi.Controllers;
using Niue.Abp.Abp.Web.Common.Web.Models;
using Niue.Application.BaseDto;
using Niue.Common;
using Niue.WebApi.Api.Models;

namespace Niue.WebApi.Api.Controllers
{
    public class HomeController : AbpApiController
    {
        public HomeController()
        {

        }

        [HttpPost]
        public async Task<AjaxResponse> ApplyBusinessUser(ApplyBusinessUserApiInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Name))
            {
                return new AjaxResponse(new ResultDto { Code = 10, Message = "公司名称不能为空。" });
            }
            if (string.IsNullOrWhiteSpace(input.Linkman))
            {
                return new AjaxResponse(new ResultDto { Code = 10, Message = "联系人不能为空。" });
            }
            if (string.IsNullOrWhiteSpace(input.LinkmanMobile))
            {
                return new AjaxResponse(new ResultDto { Code = 10, Message = "联系电话不能为空。" });
            }
            if (!RegVerifyHelper.IsMobile(input.LinkmanMobile))
            {
                return new AjaxResponse(new ResultDto { Code = 10, Message = "联系电话必须为手机号。" });
            }
            return new AjaxResponse(new ResultDto {Code = 0, Message = "申请成功！请等待审核，审核通过后会有工作人员与您联系。"});
        }

        [HttpPost]
        public async Task<AjaxResponse> ApplyUmanager(ApplyUmanagerApiInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Linkman))
            {
                return new AjaxResponse(new ResultDto { Code = 10, Message = "姓名不能为空。" });
            }
            if (string.IsNullOrWhiteSpace(input.IdentificationNumber))
            {
                return new AjaxResponse(new ResultDto { Code = 10, Message = "身份证号不能为空。" });
            }
            return new AjaxResponse(new ResultDto { Code = 0, Message = "申请成功！请等待审核，审核通过后会有工作人员与您联系。" });
        }
    }
}
