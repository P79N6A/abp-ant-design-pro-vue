﻿/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：GetCardMerchantJsonResult.cs
    文件功能描述：拉取单个子商户信息的返回结果
    
    
    创建标识：Senparc - 20160520
    
    修改标识：Senparc - 20160520
    修改描述：整理接口
----------------------------------------------------------------*/

using Niue.WeChat.Core.Entities.JsonResult;

namespace Niue.WeChat.PublicAccounts.AdvancedAPIs.Card.Submerchat
{
    /// <summary>
    /// 拉取单个子商户信息的返回结果
    /// </summary>
    public class GetCardMerchantJsonResult : WxJsonResult 
    {
        /// <summary>
        /// 
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int primary_category_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int secondary_category_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string submit_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int result { get; set; }
        
    }
  
}
