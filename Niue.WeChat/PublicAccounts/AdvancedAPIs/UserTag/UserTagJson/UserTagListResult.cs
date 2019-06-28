using System.Collections.Generic;
using Niue.WeChat.Core.Entities.JsonResult;

namespace Niue.WeChat.PublicAccounts.AdvancedAPIs.UserTag.UserTagJson
{
    public class UserTagListResult :WxJsonResult
    {
        public List<int> tagid_list { get; set; }
    }
}
