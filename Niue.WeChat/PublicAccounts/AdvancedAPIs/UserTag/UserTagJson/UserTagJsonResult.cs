using System.Collections.Generic;
using Niue.WeChat.Core.Entities.JsonResult;

namespace Niue.WeChat.PublicAccounts.AdvancedAPIs.UserTag.UserTagJson
{
    public class UserTagJsonResult:WxJsonResult 
    {
        public int count { get; set; }
        public UserTagList data { get; set; }
        public string next_openid { get; set; }
    }
    public class UserTagList
    {
        public List<string> openid { get; set; }
    }
}
