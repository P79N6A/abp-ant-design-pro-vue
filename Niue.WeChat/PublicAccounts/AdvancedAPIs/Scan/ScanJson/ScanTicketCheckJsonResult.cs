﻿/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：ScanTicketCheckJsonResult.cs
    文件功能描述： 检查wxticket参数的返回结果
    
    
    创建标识：Senparc - 20160520
    
----------------------------------------------------------------*/

using Niue.WeChat.Core.Entities.JsonResult;

namespace Niue.WeChat.PublicAccounts.AdvancedAPIs.Scan.ScanJson
{
    /// <summary>
    /// 检查wxticket参数的返回结果
    /// </summary>
    public class ScanTicketCheckJsonResult : WxJsonResult 
    {
        /// <summary>
        /// 商品编码标准。
        /// </summary>
        public string keystandard { get; set; }
        /// <summary>
        /// 商品编码内容。
        /// </summary>
        public string keystr { get; set; }
        /// <summary>
        /// 当前访问者的openid，可唯一标识用户。
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 打开商品主页的场景，scan为扫码，others为其他场景，可能是会话、收藏或朋友圈。
        /// </summary>
        public string scene { get; set; }
        /// <summary>
        /// 该条码（二维码）是否被扫描，true为是，false为否。
        /// </summary>
        public string is_check { get; set; }
        /// <summary>
        /// 是否关注公众号，true为已关注，false为未关注。
        /// </summary>
        public string is_contact { get; set; }
    }
}
