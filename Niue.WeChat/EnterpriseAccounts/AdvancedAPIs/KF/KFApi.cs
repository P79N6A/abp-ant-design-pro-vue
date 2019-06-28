﻿/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：KFApi.cs
    文件功能描述：发送客服消息
    
    
    创建标识：Senparc - 20160309
 
    修改标识：Senparc - 20160720
    修改描述：增加其接口的异步方法
 
----------------------------------------------------------------*/

/*
    官方文档：http://qydev.weixin.qq.com/wiki/index.php?title=%E4%BC%81%E4%B8%9A%E5%AE%A2%E6%9C%8D%E6%8E%A5%E5%8F%A3%E8%AF%B4%E6%98%8E
 */

using System.Threading.Tasks;
using Niue.WeChat.Core;
using Niue.WeChat.Core.Entities.JsonResult;
using Niue.WeChat.EnterpriseAccounts.CommonAPIs;

namespace Niue.WeChat.EnterpriseAccounts.AdvancedAPIs.KF
{
    /// <summary>
    /// 发送消息
    /// </summary>
    public static class KFApi
    {
        private const string URL_FORMAT = "https://qyapi.weixin.qq.com/cgi-bin/kf/send?access_token={0}";
        #region 同步请求
        
        
        /// <summary>
        /// 发送文本信息
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="senderType">发送人类型</param>
        /// <param name="senderId">发送人标志</param>
        /// <param name="receiverType">接收人类型</param>
        /// <param name="receiverId">接收人标志</param>
        /// <param name="content">消息内容</param>
        /// <param name="timeOut">代理请求超时时间（毫秒）</param>
        /// <returns></returns>
        public static QyJsonResult SendText(string accessToken, KF_User_Type senderType, string senderId, KF_User_Type receiverType,
            string receiverId, string content, int timeOut = Config.TIME_OUT)
        {
            var data = new
            {
                sender = new
                {
                    type = senderType.ToString(),
                    id = senderId
                },
                receiver = new
                {
                    type = receiverType.ToString(),
                    id = receiverId
                },
                msgtype = "text",
                text = new
                {
                    content
                }
            };
            return CommonJsonSend.Send<QyJsonResult>(accessToken, URL_FORMAT, data, CommonJsonSendType.POST, timeOut);
        }

        /// <summary>
        /// 发送图片信息
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="senderType">发送人类型</param>
        /// <param name="senderId">发送人标志</param>
        /// <param name="receiverType">接收人类型</param>
        /// <param name="receiverId">接收人标志</param>
        /// <param name="mediaId">图片的mediaId</param>
        /// <param name="timeOut">代理请求超时时间（毫秒）</param>
        /// <returns></returns>
        public static QyJsonResult SendImage(string accessToken, KF_User_Type senderType, string senderId, KF_User_Type receiverType,
            string receiverId, string mediaId, int timeOut = Config.TIME_OUT)
        {
            var data = new
            {
                sender = new
                {
                    type = senderType.ToString(),
                    id = senderId
                },
                receiver = new
                {
                    type = receiverType.ToString(),
                    id = receiverId
                },
                msgtype = "image",
                image = new
                {
                    media_id = mediaId
                }
            };
            return CommonJsonSend.Send<QyJsonResult>(accessToken, URL_FORMAT, data, CommonJsonSendType.POST, timeOut);
        }

        /// <summary>
        /// 发送文件信息
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="senderType">发送人类型</param>
        /// <param name="senderId">发送人标志</param>
        /// <param name="receiverType">接收人类型</param>
        /// <param name="receiverId">接收人标志</param>
        /// <param name="mediaId">文件的mediaId</param>
        /// <param name="timeOut">代理请求超时时间（毫秒）</param>
        /// <returns></returns>
        public static QyJsonResult SendFile(string accessToken, KF_User_Type senderType, string senderId, KF_User_Type receiverType,
            string receiverId, string mediaId, int timeOut = Config.TIME_OUT)
        {
            var data = new
            {
                sender = new
                {
                    type = senderType.ToString(),
                    id = senderId
                },
                receiver = new
                {
                    type = receiverType.ToString(),
                    id = receiverId
                },
                msgtype = "file",
                file = new
                {
                    media_id = mediaId
                }
            };
            return CommonJsonSend.Send<QyJsonResult>(accessToken, URL_FORMAT, data, CommonJsonSendType.POST, timeOut);
        }

        /// <summary>
        /// 发送语音信息
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="senderType">发送人类型</param>
        /// <param name="senderId">发送人标志</param>
        /// <param name="receiverType">接收人类型</param>
        /// <param name="receiverId">接收人标志</param>
        /// <param name="mediaId">语音的mediaId</param>
        /// <param name="timeOut">代理请求超时时间（毫秒）</param>
        /// <returns></returns>
        public static QyJsonResult SendVoice(string accessToken, KF_User_Type senderType, string senderId, KF_User_Type receiverType,
            string receiverId, string mediaId, int timeOut = Config.TIME_OUT)
        {
            var data = new
            {
                sender = new
                {
                    type = senderType.ToString(),
                    id = senderId
                },
                receiver = new
                {
                    type = receiverType.ToString(),
                    id = receiverId
                },
                msgtype = "voice",
                voice = new
                {
                    media_id = mediaId
                }
            };
            return CommonJsonSend.Send<QyJsonResult>(accessToken, URL_FORMAT, data, CommonJsonSendType.POST, timeOut);
        }

        /// <summary>
        /// 获取客服列表
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="type">不填时，同时返回内部、外部客服列表</param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static GetKFListResult GetKFList(string accessToken, KF_Type? type = null, int timeOut = Config.TIME_OUT)
        {
            var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/kf/list?access_token={0}&type={1}", accessToken, type);

            return CommonJsonSend.Send<GetKFListResult>(null, url, null, CommonJsonSendType.GET, timeOut);
        }
        #endregion

        #region 异步请求
         /// <summary>
        /// 【异步方法】发送文本信息
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="senderType">发送人类型</param>
        /// <param name="senderId">发送人标志</param>
        /// <param name="receiverType">接收人类型</param>
        /// <param name="receiverId">接收人标志</param>
        /// <param name="content">消息内容</param>
        /// <param name="timeOut">代理请求超时时间（毫秒）</param>
        /// <returns></returns>
        public static async Task<QyJsonResult> SendTextAsync(string accessToken, KF_User_Type senderType, string senderId, KF_User_Type receiverType,
            string receiverId, string content, int timeOut = Config.TIME_OUT)
        {
            var data = new
            {
                sender = new
                {
                    type = senderType.ToString(),
                    id = senderId
                },
                receiver = new
                {
                    type = receiverType.ToString(),
                    id = receiverId
                },
                msgtype = "text",
                text = new
                {
                    content
                }
            };
            return await Core.CommonAPIs.CommonJsonSend.SendAsync<QyJsonResult>(accessToken, URL_FORMAT, data, CommonJsonSendType.POST, timeOut);
        }

        /// <summary>
        /// 【异步方法】发送图片信息
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="senderType">发送人类型</param>
        /// <param name="senderId">发送人标志</param>
        /// <param name="receiverType">接收人类型</param>
        /// <param name="receiverId">接收人标志</param>
        /// <param name="mediaId">图片的mediaId</param>
        /// <param name="timeOut">代理请求超时时间（毫秒）</param>
        /// <returns></returns>
        public static async Task<QyJsonResult> SendImageAsync(string accessToken, KF_User_Type senderType, string senderId, KF_User_Type receiverType,
            string receiverId, string mediaId, int timeOut = Config.TIME_OUT)
        {
            var data = new
            {
                sender = new
                {
                    type = senderType.ToString(),
                    id = senderId
                },
                receiver = new
                {
                    type = receiverType.ToString(),
                    id = receiverId
                },
                msgtype = "image",
                image = new
                {
                    media_id = mediaId
                }
            };
            return await Core.CommonAPIs.CommonJsonSend.SendAsync<QyJsonResult>(accessToken, URL_FORMAT, data, CommonJsonSendType.POST, timeOut);
        }

        /// <summary>
        /// 【异步方法】发送文件信息
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="senderType">发送人类型</param>
        /// <param name="senderId">发送人标志</param>
        /// <param name="receiverType">接收人类型</param>
        /// <param name="receiverId">接收人标志</param>
        /// <param name="mediaId">文件的mediaId</param>
        /// <param name="timeOut">代理请求超时时间（毫秒）</param>
        /// <returns></returns>
        public static async Task<QyJsonResult> SendFileAsync(string accessToken, KF_User_Type senderType, string senderId, KF_User_Type receiverType,
            string receiverId, string mediaId, int timeOut = Config.TIME_OUT)
        {
            var data = new
            {
                sender = new
                {
                    type = senderType.ToString(),
                    id = senderId
                },
                receiver = new
                {
                    type = receiverType.ToString(),
                    id = receiverId
                },
                msgtype = "file",
                file = new
                {
                    media_id = mediaId
                }
            };
            return await Core.CommonAPIs.CommonJsonSend.SendAsync<QyJsonResult>(accessToken, URL_FORMAT, data, CommonJsonSendType.POST, timeOut);
        }

        /// <summary>
        /// 【异步方法】发送语音信息
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="senderType">发送人类型</param>
        /// <param name="senderId">发送人标志</param>
        /// <param name="receiverType">接收人类型</param>
        /// <param name="receiverId">接收人标志</param>
        /// <param name="mediaId">语音的mediaId</param>
        /// <param name="timeOut">代理请求超时时间（毫秒）</param>
        /// <returns></returns>
        public static async Task<QyJsonResult> SendVoiceAsync(string accessToken, KF_User_Type senderType, string senderId, KF_User_Type receiverType,
            string receiverId, string mediaId, int timeOut = Config.TIME_OUT)
        {
            var data = new
            {
                sender = new
                {
                    type = senderType.ToString(),
                    id = senderId
                },
                receiver = new
                {
                    type = receiverType.ToString(),
                    id = receiverId
                },
                msgtype = "voice",
                voice = new
                {
                    media_id = mediaId
                }
            };
            return await Core.CommonAPIs.CommonJsonSend.SendAsync<QyJsonResult>(accessToken, URL_FORMAT, data, CommonJsonSendType.POST, timeOut);
        }

        /// <summary>
        /// 获取客服列表
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="type">不填时，同时返回内部、外部客服列表</param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static async Task<GetKFListResult> GetKFListAsync(string accessToken, KF_Type? type = null, int timeOut = Config.TIME_OUT)
        {
            var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/kf/list?access_token={0}&type={1}", accessToken, type);

            return await Core.CommonAPIs.CommonJsonSend.SendAsync<GetKFListResult>(null, url, null, CommonJsonSendType.GET, timeOut);
        }
        #endregion
    }
}
