using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace Niue.Common
{
    /// <summary>
    /// 短信平台辅助类
    /// </summary>
    public static class SmsHelper
    {
        private static readonly string IsOpen = ConfigurationManager.AppSettings["SMS.IsOpen"];
        private static readonly string Username = ConfigurationManager.AppSettings["SMS.Username"];
        private static readonly string Password = ConfigurationManager.AppSettings["SMS.Password"];
        private static readonly string Productid = ConfigurationManager.AppSettings["SMS.Productid"];
        private static readonly string VerificationCodePid = ConfigurationManager.AppSettings["SMS.VerificationCodePid"];
        private static readonly string Signature = ConfigurationManager.AppSettings["SMS.Signature"];

        /// <summary>
        /// 发送普通短信
        /// </summary>
        /// <param name="mobile">发送手机号</param>
        /// <param name="content">发送内容（不包括签名）</param>
        /// <param name="xh">小号</param>
        /// <returns></returns>
        public static SmsReulst SendSms(string mobile, string content, string xh = "")
        {
            if (IsOpen != "Open")
            {
                return new SmsReulst();
            }
            var username = Username;
            var password = Password;
            var productid = Productid;
            var signature = Signature;
            const string service = "http://www.ztsms.cn/sendNSms.do?";
            var tkey = DateTime.Now.ToString("yyyyMMddHHmmss");
            password = Md5Helper.Encrypt(password);
            password = Md5Helper.Encrypt(password + tkey);
            content = content + signature;
            content = HttpUtility.UrlEncode(content, Encoding.UTF8);
            var strUrl = service + "username=" + username + "&password=" + password + "&mobile=" + mobile + "&content=" +
                         content + "&tkey=" + tkey + "&productid=" + productid + "&xh=" + xh;
            var request = (HttpWebRequest)WebRequest.Create(strUrl);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            // ReSharper disable once AssignNullToNotNullAttribute
            var reader = new StreamReader(stream, Encoding.UTF8);
            var read = reader.ReadToEnd();
            var result = new SmsReulst();
            response.Close();
            try
            {
                var index = read.IndexOf(',');
                if (index > 0)
                {
                    read = read.Substring(0, index);
                }
                var code = Convert.ToInt32(read);
                switch (code)
                {
                    case 1:
                        result.Code = 0;
                        result.Message = ((EnumSmsResult)code).ToString();
                        result.Data = code;
                        break;
                    default:
                        result.Code = 1;
                        result.Message = ((EnumSmsResult)code).ToString();
                        result.Data = code;
                        break;
                }
            }
            catch (Exception)
            {
                result.Code = 2;
                result.Message = "服务器内部错误！";
                result.Data = null;
            }
            return result;
        }

        /// <summary>
        /// 获取短信验证码
        /// </summary>
        /// <param name="mobile">发送手机号</param>
        /// <param name="content">发送内容（不包括签名）</param>
        /// <param name="xh">小号</param>
        /// <returns></returns>
        public static SmsReulst GetSmsVerificationCode(string mobile, string content, string xh = "")
        {
            if (IsOpen != "Open")
            {
                return new SmsReulst();
            }
            var username = Username;
            var password = Password;
            var productid = VerificationCodePid;
            var signature = Signature;
            const string service = "http://www.ztsms.cn/sendNSms.do?";
            var tkey = DateTime.Now.ToString("yyyyMMddHHmmss");
            password = Md5Helper.Encrypt(password);
            password = Md5Helper.Encrypt(password + tkey);
            content = content + signature;
            content = HttpUtility.UrlEncode(content, Encoding.UTF8);
            var strUrl = service + "username=" + username + "&password=" + password + "&mobile=" + mobile + "&content=" +
                         content + "&tkey=" + tkey + "&productid=" + productid + "&xh=" + xh;
            var request = (HttpWebRequest)WebRequest.Create(strUrl);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            // ReSharper disable once AssignNullToNotNullAttribute
            var reader = new StreamReader(stream, Encoding.UTF8);
            var read = reader.ReadToEnd();
            var result = new SmsReulst();
            response.Close();
            try
            {
                var index = read.IndexOf(',');
                if (index > 0)
                {
                    read = read.Substring(0, index);
                }
                var code = Convert.ToInt32(read);
                switch (code)
                {
                    case 1:
                        result.Code = 0;
                        result.Message = ((EnumSmsResult)code).ToString();
                        result.Data = code;
                        break;
                    default:
                        result.Code = 1;
                        result.Message = ((EnumSmsResult)code).ToString();
                        result.Data = code;
                        break;
                }
            }
            catch (Exception)
            {
                result.Code = 2;
                result.Message = "服务器内部错误！";
                result.Data = null;
            }
            return result;
        }

        /// <summary>
        /// 随机生成数字验证码
        /// </summary>
        /// <param name="count">位数</param>
        /// <returns></returns>
        public static string CreateVerificationCode(int count)
        {
            var code = "";
            var random = new Random((int)DateTime.Now.Ticks);
            const string array = "0123456789";
            for (var i = 0; i < count; i++)
            {
                code = code + array.Substring(random.Next() % array.Length, 1);
            }
            return code;
        }
    }

    /// <summary>
    /// 短信返回结果
    /// </summary>
    public class SmsReulst
    {
        [Description("代码")]
        public int Code { get; set; }
        [Description("消息")]
        public string Message { get; set; }
        [Description("数据")]
        public object Data { get; set; }
    }

    /// <summary>
    /// 短信返回结果
    /// </summary>
    public enum EnumSmsResult
    {
        用户名或者密码不正确或用户禁用或者是管理账户 = -1,
        发送短信成功 = 1, //xxxxxxxx代表消息编号（消息ID,在匹配状态报告时会用到）
        发送短信失败 = 0, //xxxxxxxx代表消息编号
        余额不够或扣费错误 = 2,
        扣费失败异常 = 3, //（请联系客服）
        有效号码为空 = 6,
        短信内容为空 = 7,
        无签名 = 8, //必须，格式：【签名】
        没有Url提交权限 = 9,
        发送号码过多,
        最多支持2000个号码 = 10,
        产品id异常或产品禁用 = 11,
        参数异常 = 12,
        Tkey参数错误 = 13,
        Ip验证失败 = 15,
        Xh参数错误 = 16,
        短信内容过长 = 19 //最多支持500个, 或提交编码异常导致
    }
}
