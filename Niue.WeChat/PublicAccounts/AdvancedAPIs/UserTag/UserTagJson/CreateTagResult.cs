using Niue.WeChat.Core.Entities.JsonResult;

namespace Niue.WeChat.PublicAccounts.AdvancedAPIs.UserTag.UserTagJson
{
    public class CreateTagResult : WxJsonResult
    {
        public TagJson_Tag tag { get; set; }
    }
}
