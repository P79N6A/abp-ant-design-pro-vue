/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
 
    文件名：TenPayV3Result.cs
    文件功能描述：微信支付V3返回结果
    
    
    创建标识：Senparc - 20150211
    
    修改标识：Senparc - 20150303
    修改描述：整理接口
----------------------------------------------------------------*/

using System;
using System.Xml.Serialization;

namespace Niue.WeChat.PublicAccounts.TenPayLibV3.TenPayV3
{
    /// <summary>
    /// 基础返回结果
    /// </summary>
    [XmlRoot("xml")]
    public class TenPayV3Result
    {
        [XmlAttribute("return_code")]
        public string return_code { get; set; }
        [XmlAttribute("return_msg")]
        public string return_msg { get; set; }
    }
    /// <summary>
    /// 统一支付接口在 return_code为 SUCCESS的时候有返回
    /// </summary>
    public class Result : TenPayV3Result
    {
        /// <summary>
        /// 微信分配的公众账号ID
        /// </summary>
        [XmlAttribute("appid")]
        public string appid { get; set; }
        /// <summary>
        /// 微信支付分配的商户号
        /// </summary>
        [XmlAttribute("mch_id")]
        public string mch_id { get; set; }
        /// <summary>
        /// 微信支付分配的终端设备号
        /// </summary>
        [XmlAttribute("device_info")]
        public string device_info { get; set; }
        /// <summary>
        /// 随机字符串，不长于32 位
        /// </summary>
        [XmlAttribute("nonce_str")]
        public string nonce_str { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        [XmlAttribute("sign")]
        public string sign { get; set; }
        /// <summary>
        /// SUCCESS/FAIL
        /// </summary>
        [XmlAttribute("result_code")]
        public string result_code { get; set; }
        [XmlAttribute("err_code")]
        public string err_code { get; set; }
        [XmlAttribute("err_code_des")]
        public string err_code_des { get; set; }
    }

    /// <summary>
    /// 统一支付接口在return_code 和result_code 都为SUCCESS 的时候有返回
    /// </summary>
    public class UnifiedorderResult : Result
    {
        /// <summary>
        /// 交易类型:JSAPI、NATIVE、APP
        /// </summary>
        [XmlAttribute("trade_type")]
        public string trade_type { get; set; }
        /// <summary>
        /// 微信生成的预支付ID，用于后续接口调用中使用
        /// </summary>
        [XmlAttribute("prepay_id")]
        public string prepay_id { get; set; }
        /// <summary>
        /// trade_type为NATIVE时有返回，此参数可直接生成二维码展示出来进行扫码支付
        /// </summary>
        [XmlAttribute("code_url")]
        public string code_url { get; set; }
    }
}
