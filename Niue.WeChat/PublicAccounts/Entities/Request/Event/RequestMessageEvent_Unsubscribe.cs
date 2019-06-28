/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：RequestMessageEvent_Unsubscribe.cs
    文件功能描述：事件之取消订阅
    
    
    创建标识：Senparc - 20150211
    
    修改标识：Senparc - 20150303
    修改描述：整理接口
----------------------------------------------------------------*/

namespace Niue.WeChat.PublicAccounts.Entities.Request.Event
{
    /// <summary>
    /// 事件之取消订阅
    /// </summary>
    public class RequestMessageEvent_Unsubscribe : RequestMessageEventBase, IRequestMessageEventBase
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public override PublicAccounts.Event Event
        {
            get { return PublicAccounts.Event.unsubscribe; }
        }
    }
}
