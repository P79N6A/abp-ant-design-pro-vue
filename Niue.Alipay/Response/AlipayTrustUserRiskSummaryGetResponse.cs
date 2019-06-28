﻿using System.Xml.Serialization;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayTrustUserRiskSummaryGetResponse.
    /// </summary>
    public class AlipayTrustUserRiskSummaryGetResponse : AopResponse
    {
        /// <summary>
        /// 是否在风险名单
        /// </summary>
        [XmlElement("risk_code")]
        public string RiskCode { get; set; }
    }
}
