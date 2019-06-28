/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：GroupAddResultJson.cs
    文件功能描述：新增分组的返回结果
    
    创建标识：Senparc - 20160520
----------------------------------------------------------------*/

using Niue.WeChat.Core.Entities.JsonResult;

namespace Niue.WeChat.PublicAccounts.AdvancedAPIs.ShakeAround.ShakeAroundJson
{
    /// <summary>
    /// 新增分组的返回结果
    /// </summary>
    public class GroupAddResultJson : WxJsonResult 
    {
        public GroupAdd_Data data { get; set; }

       
    }
    public class GroupAdd_Data
    {
        /// <summary>
        /// 分组唯一标识，全局唯一
        /// </summary>
        public string group_id { get; set; }
        /// <summary>
        /// 分组名 
        /// </summary>
        public string group_name { get; set; }

    }
}
