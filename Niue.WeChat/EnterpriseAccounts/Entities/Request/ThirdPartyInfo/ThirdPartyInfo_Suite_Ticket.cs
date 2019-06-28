﻿/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：ThirdPartyInfo_Suite_Ticket.cs
    文件功能描述：推送suite_ticket协议
    
    
    创建标识：Senparc - 20150313
    
    修改标识：Senparc - 20150313
    修改描述：整理接口
----------------------------------------------------------------*/

namespace Niue.WeChat.EnterpriseAccounts.Entities.Request.ThirdPartyInfo
{
    /// <summary>
    /// 推送suite_ticket协议
    /// </summary>
    public class RequestMessageInfo_Suite_Ticket : ThirdPartyInfoBase, IThirdPartyInfoBase
    {
        public override EnterpriseAccounts.ThirdPartyInfo InfoType
        {
            get { return EnterpriseAccounts.ThirdPartyInfo.SUITE_TICKET; }
        }

        /// <summary>
        /// Ticket内容
        /// </summary>
        public string SuiteTicket { get; set; }
    }
}
