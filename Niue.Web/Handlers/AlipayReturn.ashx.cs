using System.Configuration;
using System.Web;

namespace Niue.Web.Handlers
{
    /// <summary>
    /// AlipayReturn 的摘要说明
    /// </summary>
    public class AlipayReturn : IHttpHandler
    {
        private static readonly string Url = ConfigurationManager.AppSettings["Alipay.URL"];
        private static readonly string AppId = ConfigurationManager.AppSettings["Alipay.APP_ID"];
        private static readonly string AppPrivateKey = ConfigurationManager.AppSettings["Alipay.APP_PRIVATE_KEY"];
        private static readonly string Format = ConfigurationManager.AppSettings["Alipay.FORMAT"];
        private static readonly string Charset = ConfigurationManager.AppSettings["Alipay.CHARSET"];
        private static readonly string AlipayPublicKey = ConfigurationManager.AppSettings["Alipay.ALIPAY_PUBLIC_KEY"];
        private static readonly string SignType = ConfigurationManager.AppSettings["Alipay.SIGN_TYPE"];
        private HttpContext _context;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            _context = context;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}