﻿/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：ResponseMessageNoResponse.cs
    文件功能描述：无需响应（回复空字符串）的响应类型
    
    
    创建标识：Senparc - 20150505
    
----------------------------------------------------------------*/

using Niue.WeChat.Core.Entities.Response;

namespace Niue.WeChat.EnterpriseAccounts.Entities.Response
{
    /// <summary>
    /// 当MessageHandler接收到IResponseNothing的返回类型参数时，只会向微信服务器返回空字符串，等同于return null
    /// </summary>
    public class ResponseMessageNoResponse : ResponseMessageBase,IResponseMessageNoResponse
    {
    }
}
