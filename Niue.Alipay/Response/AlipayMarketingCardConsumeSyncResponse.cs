﻿using System.Xml.Serialization;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayMarketingCardConsumeSyncResponse.
    /// </summary>
    public class AlipayMarketingCardConsumeSyncResponse : AopResponse
    {
        /// <summary>
        /// 外部卡号
        /// </summary>
        [XmlElement("external_card_no")]
        public string ExternalCardNo { get; set; }
    }
}
