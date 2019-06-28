using System;
using System.Configuration;
using Niue.Common;

namespace Niue.Aliyun
{
    /// <summary>
    /// 直播
    /// </summary>
    public class Live
    {
        /// <summary>
        /// 推流地址
        /// </summary>
        private static readonly string PushFlowAddress = ConfigurationManager.AppSettings["Aliyun.PushFlowAddress"];
        /// <summary>
        /// 播放地址
        /// </summary>
        private static readonly string PlayFlowAddress = ConfigurationManager.AppSettings["Aliyun.PlayFlowAddress"];
        /// <summary>
        /// 直播私有密钥
        /// </summary>
        private static readonly string LivePrivateKey = ConfigurationManager.AppSettings["Aliyun.LivePrivateKey"];

        /// <summary>
        /// 获取直播鉴权
        /// </summary>
        /// <param name="streamName">流名称（直播间名称）</param>
        /// <param name="authTime">鉴权时间(s)</param>
        /// <returns></returns>
        public static LiveValue GetAuthKey(string streamName, int authTime)
        {
            const string appName = "FingertipClub";
            var sstring = "{URI}-{Timestamp}-{rand}-{uid}-{PrivateKey}";
            var pushFlowAddress = PushFlowAddress.Replace("{AppName}", appName).Replace("{StreamName}", streamName);
            var playFlowAddress = PlayFlowAddress.Replace("{AppName}", appName).Replace("{StreamName}", streamName);
            var liveValue = new LiveValue();
            liveValue.CreationTime = DateTime.Now;
            var timestamp = (liveValue.CreationTime.Value.Ticks - new DateTime(1970, 1, 1).Ticks)/ 10000000 + authTime;
            const int rand = 0;
            const string uid = "0";
            sstring =
                sstring.Replace("{URI}", "/" + appName + "/" + streamName)
                    .Replace("{Timestamp}", timestamp.ToString())
                    .Replace("{rand}", rand.ToString())
                    .Replace("{uid}", uid)
                    .Replace("{PrivateKey}", LivePrivateKey);
            var md5Hash = Md5Helper.Encrypt(sstring);
            if (pushFlowAddress.Contains("?"))
            {
                pushFlowAddress = pushFlowAddress + "&auth_key={timestamp}-{rand}-{uid}-{md5hash}";
            }
            else
            {
                pushFlowAddress = pushFlowAddress + "?auth_key={timestamp}-{rand}-{uid}-{md5hash}";
            }
            if (playFlowAddress.Contains("?"))
            {
                playFlowAddress = playFlowAddress + "&auth_key={timestamp}-{rand}-{uid}-{md5hash}";
            }
            else
            {
                playFlowAddress = playFlowAddress + "?auth_key={timestamp}-{rand}-{uid}-{md5hash}";
            }
            //推流鉴权地址示例：rtmp://video-center-bj.alivecdn.com/AppName/StreamName?vhost=live8.zhijianst.com&auth_key=1519711814-0-0-16395bff667209ada7ee34f4695ccfab
            liveValue.AuthPushAddress =
                pushFlowAddress.Replace("{timestamp}", timestamp.ToString())
                    .Replace("{rand}", rand.ToString())
                    .Replace("{uid}", uid)
                    .Replace("{md5hash}", md5Hash);
            //播放鉴权地址示例：rtmp://live8.zhijianst.com/AppName/StreamName?auth_key=1519710015-0-0-ad83da7929975342ed6626240494ce9f
            liveValue.AuthPlayAddress =
                playFlowAddress.Replace("{timestamp}", timestamp.ToString())
                    .Replace("{rand}", rand.ToString())
                    .Replace("{uid}", uid)
                    .Replace("{md5hash}", md5Hash);
            return liveValue;
        }
    }

    public class LiveValue
    {
        /// <summary>
        /// 鉴权推流地址
        /// </summary>
        public string AuthPushAddress { get; set; }
        /// <summary>
        /// 鉴权播放地址
        /// </summary>
        public string AuthPlayAddress { get; set; }
        public DateTime? CreationTime { get; set; }
    }
}
