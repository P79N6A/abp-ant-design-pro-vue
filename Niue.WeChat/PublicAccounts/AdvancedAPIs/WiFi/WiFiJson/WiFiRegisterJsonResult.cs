/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：WiFiRegisterJsonResult.cs
    文件功能描述：添加portal型设备的返回结果
    
    创建标识：Senparc - 20160520
----------------------------------------------------------------*/

using Niue.WeChat.Core.Entities.JsonResult;

namespace Niue.WeChat.PublicAccounts.AdvancedAPIs.WiFi.WiFiJson
{
    /// <summary>
    /// 添加portal型设备的返回结果
    /// </summary>
    public class WiFiRegisterJsonResult : WxJsonResult 
    {
        public Register_Data data { get; set; }

       
    }
    public class Register_Data
    {
        public string secretkey { get; set; }
    }
}
