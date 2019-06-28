/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：RequestMessageEvent_ShakearoundUserShake.cs
    文件功能描述：事件之弹出微信相册发图器(ShakearoundUserShake)
    
    
    创建标识：Senparc - 20150914
----------------------------------------------------------------*/

using System.Collections.Generic;

namespace Niue.WeChat.PublicAccounts.Entities.Request.Event
{
    /// <summary>
    /// 事件之摇一摇事件通知(ShakearoundUserShake)
    /// </summary>
    public class RequestMessageEvent_ShakearoundUserShake : RequestMessageEventBase, IRequestMessageEventBase
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public override PublicAccounts.Event Event
        {
            get { return PublicAccounts.Event.ShakearoundUserShake; }
        }

        /// <summary>
        /// 最近的IBeacon信息
        /// </summary>
        public ChosenBeacon ChosenBeacon { get; set; }

        /// <summary>
        /// 附近的IBeacon信息
        /// </summary>
        public List<AroundBeacon> AroundBeacons { get; set; }
    }
}
