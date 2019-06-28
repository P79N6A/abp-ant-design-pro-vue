/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：RequestMessageEvent_Unsubscribe.cs
    文件功能描述：事件之取消关注事件的推送（unsubscribe）
    
    
    创建标识：Senparc - 20150313
    
    修改标识：Senparc - 20150313
    修改描述：整理接口
----------------------------------------------------------------*/

namespace Niue.WeChat.EnterpriseAccounts.Entities.Request.Event
{
    /// <summary>
    /// 事件之取消关注事件的推送（unsubscribe）
    /// </summary>
    public class RequestMessageEvent_UnSubscribe : RequestMessageEventBase, IRequestMessageEventBase
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public override EnterpriseAccounts.Event Event
        {
            get { return EnterpriseAccounts.Event.unsubscribe; }
        }
    }
}
