﻿using Niue.WeChat.Core.Entities.JsonResult;

namespace Niue.WeChat.PublicAccounts.AdvancedAPIs.Scan.ScanJson
{
    public class ProductCreateResultJson : WxJsonResult 
    {
        /// <summary>
        /// 转译后的商品id，将直接编入“获取商品二维码接口”返回的二维码内容。
        /// </summary>
        public string pid { get; set; }
    }
}
