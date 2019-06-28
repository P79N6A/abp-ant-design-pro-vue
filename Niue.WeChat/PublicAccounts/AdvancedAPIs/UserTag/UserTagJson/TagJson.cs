using System.Collections.Generic;
using Niue.WeChat.Core.Entities.JsonResult;

namespace Niue.WeChat.PublicAccounts.AdvancedAPIs.UserTag.UserTagJson
{
    public class TagJson : WxJsonResult
    {
        public List<TagJson_Tag> tags { get; set; }
    }
    public class TagJson_Tag
    {
        public int id { get; set; }
        public string name { get; set; }
        public int count { get; set; }
    }
}
