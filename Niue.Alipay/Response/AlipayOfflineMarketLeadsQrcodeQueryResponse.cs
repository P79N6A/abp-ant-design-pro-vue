﻿using System.Xml.Serialization;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayOfflineMarketLeadsQrcodeQueryResponse.
    /// </summary>
    public class AlipayOfflineMarketLeadsQrcodeQueryResponse : AopResponse
    {
        /// <summary>
        /// 开店二维码URL地址
        /// </summary>
        [XmlElement("qr_code")]
        public string QrCode { get; set; }
    }
}
