﻿using System.Xml.Serialization;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayMarketingCdpAdvertiseCreateResponse.
    /// </summary>
    public class AlipayMarketingCdpAdvertiseCreateResponse : AopResponse
    {
        /// <summary>
        /// 创建广告唯一标识
        /// </summary>
        [XmlElement("ad_id")]
        public string AdId { get; set; }
    }
}