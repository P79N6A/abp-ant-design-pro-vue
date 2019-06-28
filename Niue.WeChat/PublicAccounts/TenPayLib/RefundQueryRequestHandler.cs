using System.Web;

namespace Niue.WeChat.PublicAccounts.TenPayLib
{
    public class RefundQueryRequestHandler : ClientRequestHandler
    {
        /// <summary>
        /// 退款明细查询接口
        /// </summary>
        /// <param name="httpContext"></param>
        public RefundQueryRequestHandler(HttpContext httpContext)
            : base(httpContext)
        {
            this.SetGateUrl("https://gw.tenpay.com/gateway/normalrefundquery.xml");
        }
    }
}
