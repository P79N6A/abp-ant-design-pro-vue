using System;
using System.Configuration;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Niue.Application.AppServices.AppWeChatPays.Dto;
using Niue.Application.BaseDto;
using Niue.Common;
using Niue.WeChat.PublicAccounts.TenPayLibV3;
using Niue.WeChat.PublicAccounts.TenPayLibV3.TenPayV3;
using RequestHandler = Niue.WeChat.PublicAccounts.TenPayLibV3.RequestHandler;

namespace Niue.Application.AppServices.AppWeChatPays
{
    public class AppWeChatPayService : IAppWeChatPayService
    {
        private static readonly string ServerPath = ConfigurationManager.AppSettings["ServerPath"];
        private static readonly string AppId = ConfigurationManager.AppSettings["WeChat.Open.AppID"];
        private static readonly string AppSecret = ConfigurationManager.AppSettings["WeChat.Open.AppSecret"];
        private static readonly string MchId = ConfigurationManager.AppSettings["WeChat.Open.MchId"];
        private static readonly string Key = ConfigurationManager.AppSettings["WeChat.Open.Key"];
        private static readonly string TenPayV3Notify = ConfigurationManager.AppSettings["WeChat.Open.TenPayV3Notify"];

        private readonly TenPayV3Info _tenPayV3Info;

        public AppWeChatPayService()
        {
            _tenPayV3Info = new TenPayV3Info(AppId, AppSecret, MchId, Key, ServerPath + TenPayV3Notify);
            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        /// <summary>
        /// 生成APP支付订单信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ResultDto> GetPayInfo(GetPayInfoInput input)
        {
            var requestHandler = new RequestHandler();
            //微信开放平台审核通过的应用APPID
            requestHandler.SetParameter("appid", _tenPayV3Info.AppId);
            //微信支付分配的商户号
            requestHandler.SetParameter("mch_id", _tenPayV3Info.MchId);
            //终端设备号(门店号或收银设备ID)，默认请传"WEB"
            requestHandler.SetParameter("device_info", "WEB");
            //随机字符串，不长于32位。推荐随机数生成算法
            requestHandler.SetParameter("nonce_str", TenPayV3Util.GetNoncestr());
            //签名，详见签名生成算法
            //requestHandler.SetParameter("sign", "");
            //签名类型，目前支持HMAC-SHA256和MD5，默认为MD5
            //requestHandler.SetParameter("sign_type", "MD5");
            //商品描述交易字段格式根据不同的应用场景按照以下格式：APP——需传入应用市场上的APP名字 - 实际商品名称，天天爱消除 - 游戏充值。
            requestHandler.SetParameter("body", "报名费用。");
            //商品详细列表，使用Json格式，传输签名前请务必使用CDATA标签将JSON文本串保护起来。goods_detail 服务商必填[]：└ goods_id String 必填 32 商品的编号└ wxpay_goods_id String 可选 32 微信支付定义的统一商品编号└ goods_name String 必填 256 商品名称└ quantity Int 必填 商品数量└ price Int 必填 商品单价，单位为分└ goods_category String 可选 32 商品类目ID└ body String 可选 1000 商品描述信息
            //requestHandler.SetParameter("detail", json);
            //附加数据，在查询API和支付通知中原样返回，该字段主要用于商户携带订单的自定义数据
            requestHandler.SetParameter("attach", "");
            //商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。详见商户订单号
            requestHandler.SetParameter("out_trade_no", "123456");
            //符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
            //requestHandler.SetParameter("fee_type", "CNY");
            //订单总金额，单位为分，详见支付金额
            requestHandler.SetParameter("total_fee", "100");
            //用户端实际ip
            if (string.IsNullOrWhiteSpace(input.SpbillCreateIp))
            {
                requestHandler.SetParameter("spbill_create_ip", HostAddressHelper.GetHostAddress());
            }
            else
            {
                requestHandler.SetParameter("spbill_create_ip", input.SpbillCreateIp);
            }
            //订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。其他详见时间规则
            requestHandler.SetParameter("time_start", DateTime.Now.ToString("yyyyMMddHHmmss"));
            //订单失效时间，格式为yyyyMMddHHmmss，如2009年12月27日9点10分10秒表示为20091227091010。其他详见时间规则 注意：最短失效时间间隔必须大于5分钟
            requestHandler.SetParameter("time_expire", DateTime.Now.AddMinutes(15).ToString("yyyyMMddHHmmss"));
            //订单优惠标记，代金券或立减优惠功能的参数，说明详见代金券或立减优惠
            //requestHandler.SetParameter("goods_tag", "WXG");
            //接收微信支付异步通知回调地址，通知url必须为直接可访问的url，不能携带参数。
            requestHandler.SetParameter("notify_url", _tenPayV3Info.TenPayV3Notify);
            Logger.Debug("WeChatPay-GetPayInfo-notify_url-" + _tenPayV3Info.TenPayV3Notify);
            //支付类型
            requestHandler.SetParameter("trade_type", "APP");
            //no_credit--指定不能使用信用卡支付
            //requestHandler.SetParameter("limit_pay", "no_credit");
            //设置KEY
            requestHandler.SetKey(_tenPayV3Info.Key);

            var sign = requestHandler.CreateMd5Sign();
            string data = requestHandler.ParseXML(sign);
            requestHandler.GetDebugInfo();
            Logger.Debug("WeChatPay-GetPayInfo-xml-" + data);
            var result = await TenPayV3.UnifiedorderAsync(data);
            var tenPayV3Result = XmlHelper.WxXmlToObject<TenPayV3Result>(result);
            if (tenPayV3Result.return_code == "SUCCESS")
            {
                var unifiedorderResult = XmlHelper.WxXmlToObject<UnifiedorderResult>(result);
                var tenPayV3App = new TenPayV3App();
                tenPayV3App.appid = unifiedorderResult.appid;
                tenPayV3App.partnerid = unifiedorderResult.mch_id;
                tenPayV3App.prepayid = unifiedorderResult.prepay_id;
                tenPayV3App.package = "Sign=WXPay";
                tenPayV3App.packageValue = "Sign=WXPay";
                tenPayV3App.noncestr = TenPayV3Util.GetNoncestr();
                tenPayV3App.timestamp = TenPayV3Util.GetTimestamp();
                var handler = new RequestHandler();
                handler.SetParameter("appid", tenPayV3App.appid);
                handler.SetParameter("partnerid", tenPayV3App.partnerid);
                handler.SetParameter("prepayid", tenPayV3App.prepayid);
                handler.SetParameter("package", tenPayV3App.package);
                handler.SetParameter("noncestr", tenPayV3App.noncestr);
                handler.SetParameter("timestamp", tenPayV3App.timestamp);
                handler.SetKey(_tenPayV3Info.Key);
                tenPayV3App.sign = handler.CreateMd5Sign();
                return new ResultDto { Code = 0, Message = "生成APP支付订单信息", Data = tenPayV3App };
            }
            
            return new ResultDto { Code = 10, Message = tenPayV3Result.return_msg };
        }

        /// <summary>
        /// 支付状态异步通知
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ResultDto> PayNotify(PayNotifyInput input)
        {
            //0ba47efc-ac09-4174-9678-330531eb7910
            var no = input.No.Substring(0, 8) + "-" + input.No.Substring(8, 4) + "-" + input.No.Substring(12, 4) + "-" +
                     input.No.Substring(16, 4) + "-" + input.No.Substring(20, 12);
            Logger.Debug("AppWeChatPayService-PayNotify-" + no);
            if (input.ResultCode == "SUCCESS")
            {
                Logger.Debug("AppWeChatPayService-PayNotify-SUCCESS");
            }
            if (input.ResultCode == "FAIL")
            {
                //未付款交易超时关闭，或支付完成后全额退款
                Logger.Debug("AppWeChatPayService-PayNotify-FAIL");
            }
            return new ResultDto { Code = 0, Message = "支付状态异步通知", Data = input };
        }
    }
}