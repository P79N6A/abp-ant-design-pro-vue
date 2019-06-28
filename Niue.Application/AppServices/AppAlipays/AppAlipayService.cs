using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using Castle.Core.Logging;
using Niue.Alipay;
using Niue.Alipay.Domain;
using Niue.Alipay.Request;
using Niue.Aliyun;
using Niue.Application.AppServices.AppAlipays.Dto;
using Niue.Application.BaseDto;

namespace Niue.Application.AppServices.AppAlipays
{
    public class AppAlipayService : IAppAlipayService
    {
        private static readonly string Url = ConfigurationManager.AppSettings["Alipay.URL"];
        private static readonly string AppId = ConfigurationManager.AppSettings["Alipay.APP_ID"];
        private static readonly string AppPrivateKey = ConfigurationManager.AppSettings["Alipay.APP_PRIVATE_KEY"];
        private static readonly string Format = ConfigurationManager.AppSettings["Alipay.FORMAT"];
        private static readonly string Charset = ConfigurationManager.AppSettings["Alipay.CHARSET"];
        private static readonly string AlipayPublicKey = ConfigurationManager.AppSettings["Alipay.ALIPAY_PUBLIC_KEY"];
        private static readonly string SignType = ConfigurationManager.AppSettings["Alipay.SIGN_TYPE"];
        private static readonly string ServerPath = ConfigurationManager.AppSettings["ServerPath"];

        private readonly IAopClient _client;
        public ILogger Logger { get; set; }

        public AppAlipayService()
        {
            _client = new DefaultAopClient(Url, AppId, AppPrivateKey, Format, "1.0", SignType, AlipayPublicKey, Charset);
            Logger = NullLogger.Instance;
        }

        /// <summary>
        /// 生成APP支付订单信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ResultDto> GetPayInfo(GetPayInfoInput input)
        {
            var request = new AlipayTradeAppPayRequest();
            //SDK已经封装掉了公共参数，这里只需要传入业务参数。以下方法为sdk的model入参方式(model和biz_content同时存在的情况下取biz_content)。
            var model = new AlipayTradeAppPayModel();
            model.Body = "报名费用。";
            model.Subject = "报名缴费";
            model.TotalAmount = "0.00";
            model.ProductCode = "QUICK_MSECURITY_PAY";
            model.OutTradeNo = "123456";
            model.TimeoutExpress = "15m";
            request.SetNotifyUrl(ServerPath + "/Handlers/AlipayNotify.ashx");
            request.SetBizModel(model);
            //这里和普通的接口调用不同，使用的是sdkExecute
            var response = _client.SdkExecute(request);
            //HttpUtility.HtmlEncode是为了输出到页面时防止被浏览器将关键参数html转义，实际打印到日志以及http传输不会有这个问题
            return new ResultDto { Code = 0, Message = "生成APP支付订单信息", Data = HttpUtility.HtmlEncode(response.Body).Replace("amp;", "") };
        }

        /// <summary>
        /// 支付状态异步通知
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ResultDto> PayNotify(PayNotifyInput input)
        {
            if (input.trade_status == "TRADE_SUCCESS")
            {

            }
            if (input.trade_status == "TRADE_CLOSED")
            {
                //未付款交易超时关闭，或支付完成后全额退款

            }
            if (input.trade_status == "TRADE_FINISHED")
            {
                //交易结束，不可退款

            }
            return new ResultDto { Code = 0, Message = "支付状态异步通知", Data = input };
        }

        public async Task<ResultDto> TestLive(TestLiveInput input)
        {
            var liveValue = Live.GetAuthKey(input.StreamName, input.AuthTime);
            return new ResultDto { Code = 0, Message = "鉴权成功！", Data = liveValue };
        }
    }
}