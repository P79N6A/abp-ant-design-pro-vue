using System.Collections.Generic;
using System.Configuration;
using System.Web;
using Niue.Abp.Abp.Logging;
using Niue.Alipay.Util;
using Niue.Common;

namespace Niue.Web.Handlers
{
    /// <summary>
    /// AlipayNotify 的摘要说明
    /// 支付宝统一订单请求回调接口
    /// </summary>
    public class AlipayNotify : IHttpHandler
    {
        //private static readonly string Url = ConfigurationManager.AppSettings["Alipay.URL"];
        //private static readonly string AppId = ConfigurationManager.AppSettings["Alipay.APP_ID"];
        //private static readonly string AppPrivateKey = ConfigurationManager.AppSettings["Alipay.APP_PRIVATE_KEY"];
        //private static readonly string Format = ConfigurationManager.AppSettings["Alipay.FORMAT"];
        private static readonly string Charset = ConfigurationManager.AppSettings["Alipay.CHARSET"];
        private static readonly string AlipayPublicKey = ConfigurationManager.AppSettings["Alipay.ALIPAY_PUBLIC_KEY"];
        private static readonly string SignType = ConfigurationManager.AppSettings["Alipay.SIGN_TYPE"];
        private static readonly string ServerPath = ConfigurationManager.AppSettings["ServerPath"];
        private HttpContext _context;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            _context = context;
            Notify();
        }

        private void Notify()
        {
            //切记alipaypublickey是支付宝的公钥，请去open.alipay.com对应应用下查看。
            //bool RSACheckV1(IDictionary<string, string> parameters, string alipaypublicKey, string charset, string signType, bool keyFromFile)
            var flag = AlipaySignature.RSACheckV1(GetRequestPost(), AlipayPublicKey, Charset, SignType, false);
            LogHelper.Logger.Debug("Notify-" + flag);
            if (flag)
            {
                const string serviceUrl = "{0}/api/services/app/{1}/{2}";
                var url = string.Format(serviceUrl, ServerPath, "AppAlipayService", "PayNotify");
                LogHelper.Logger.Debug("Notify-url-" + url);
                var param = GetParams();
                LogHelper.Logger.Debug("Notify-param-" + param);
                var post = ApiCallingHelper.Post(url, param);
                LogHelper.Logger.Debug("Notify-data-" + post);
            }
        }

        private string GetParams()
        {
            int i;
            var str = "";
            //Load Form variables into NameValueCollection variable.
            var coll = _context.Request.Form;
            // Get names of all forms into a string array.
            var requestItem = coll.AllKeys;
            for (i = 0; i < requestItem.Length; i++)
            {
                if (_context.Request.Form[requestItem[i]].IndexOf('[') > -1)
                {
                    str += "\"" + requestItem[i] + "\": " + _context.Request.Form[requestItem[i]] + ",";
                }
                else
                {
                    str += "\"" + requestItem[i] + "\": \"" + _context.Request.Form[requestItem[i]] + "\", ";
                }
            }
            if (requestItem.Length > 0)
            {
                str = str.TrimEnd(',');
            }
            str = "{" + str + "}";
            return str;
        }

        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组 
        /// request回来的信息组成的数组
        private IDictionary<string, string> GetRequestPost()
        {
            int i;
            IDictionary<string, string> sArray = new Dictionary<string, string>();
            //Load Form variables into NameValueCollection variable.
            var coll = _context.Request.Form;
            // Get names of all forms into a string array.
            var requestItem = coll.AllKeys;
            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], _context.Request.Form[requestItem[i]]);
            }
            return sArray;
        }

        public bool IsReusable => false;
    }
}