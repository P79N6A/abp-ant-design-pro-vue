﻿/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：GroupGetListResultJson.cs
    文件功能描述：查询分组列表的返回结果
    
    创建标识：Senparc - 20160520
----------------------------------------------------------------*/

using System.Collections.Generic;
using Niue.WeChat.Core.Entities.JsonResult;

namespace Niue.WeChat.PublicAccounts.AdvancedAPIs.ShakeAround.ShakeAroundJson
{
    /// <summary>
    /// 查询分组列表的返回结果
    /// </summary>
    public class GroupGetListResultJson : WxJsonResult 
    {
        public GroupGetList_Data data { get; set; }
     }
    public class GroupGetList_Data
    {
        /// <summary>
        /// 此账号下现有的总分组数
        /// </summary>
        public int total_count { get; set; }
        /// <summary>
        /// 分组列表
        /// </summary>

        public List<GroupGetList_Groups> groups { get; set; }


    }
    public class GroupGetList_Groups
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
