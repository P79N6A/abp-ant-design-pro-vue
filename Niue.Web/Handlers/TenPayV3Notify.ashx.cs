using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Niue.Abp.Abp.Logging;
using Niue.WeChat.PublicAccounts.TenPayLibV3;

namespace Niue.Web.Handlers
{
    /// <summary>
    /// TenPayV3Notify 的摘要说明
    /// 微信统一订单请求回调接口
    /// </summary>
    public class TenPayV3Notify : IHttpHandler
    {
        private readonly string _serverPath = ConfigurationManager.AppSettings["ServerPath"];
        private HttpContext _context;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            _context = context;
            var responseHandler = new ResponseHandler(_context);
            Notify(responseHandler);
        }

        private void Notify(ResponseHandler responseHandler)
        {
            var returnCode = responseHandler.GetParameter("return_code");
            var returnMsg = responseHandler.GetParameter("return_msg");
            LogHelper.Logger.Info("TenPayV3Notify-return-" + returnCode + "-" + returnMsg);
            if (returnCode != "SUCCESS")
            {
                var xml = "<xml><return_code><![CDATA[FAIL]]></return_code><return_msg><![CDATA[" + returnMsg + "]]></return_msg></xml>";
                _context.Response.ContentType = "text/xml";
                _context.Response.Write(xml);
            }
            var resultCode = responseHandler.GetParameter("result_code");
            var no = responseHandler.GetParameter("out_trade_no");
            var attach = responseHandler.GetParameter("attach");
            var transactionId = responseHandler.GetParameter("transaction_id");
            var totalFee = responseHandler.GetParameter("total_fee");
            var timeEnd = responseHandler.GetParameter("time_end");

            try
            {
                const string serviceUrl = "{0}/api/services/app/{1}/{2}";
                var request = (HttpWebRequest)WebRequest.Create(string.Format(serviceUrl, _serverPath, "AppWeChatPayService", "PayNotify"));
                LogHelper.Logger.Info("send to:" + request.RequestUri);
                request.Method = "POST";
                request.ContentType = "application/json";
                var bytes = new UTF8Encoding().GetBytes("{\"resultCode\": \"" + resultCode + "\", \"no\": \"" + no + "\", \"attach\": \"" + attach + "\", \"transactionId\": \"" + transactionId + "\", \"totalFee\": \"" + totalFee + "\", \"timeEnd\": \"" + timeEnd + "\"}");
                request.ContentLength = bytes.Length;
                var requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();

                //响应微信服务器
                var returnXml = "<xml><return_code><![CDATA[SUCCESS]]></return_code><return_msg><![CDATA[OK]]></return_msg></xml>";
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8")))
                        {
                            LogHelper.Logger.Info("TenPayV3Notify-result-" + resultCode);
                            var readToEnd = streamReader.ReadToEnd();
                            var deserializeObject = (JObject)JsonConvert.DeserializeObject(readToEnd);
                            if (deserializeObject["Code"].ToString() == "0")
                            {
                                LogHelper.Logger.Info("TenPayV3Notify-" + deserializeObject["Message"]);
                            }
                            else
                            {
                                returnXml = "<xml><return_code><![CDATA[FAIL]]></return_code><return_msg><![CDATA["+ deserializeObject["Message"]+"]]></return_msg></xml>";
                            }
                        }
                    }
                }
                _context.Response.ContentType = "text/xml";
                _context.Response.Write(returnXml);
            }
            catch (Exception ex)
            {
                LogHelper.Logger.Info("TenPayV3Notify-No" + no + "-Exception-" + ex.Message);
            }
        }

        public bool IsReusable => false;
    }
}