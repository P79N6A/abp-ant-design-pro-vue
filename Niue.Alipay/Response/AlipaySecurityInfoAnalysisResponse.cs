using System.Xml.Serialization;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipaySecurityInfoAnalysisResponse.
    /// </summary>
    public class AlipaySecurityInfoAnalysisResponse : AopResponse
    {
        /// <summary>
        /// 风险标签
        /// </summary>
        [XmlElement("risk_code")]
        public string RiskCode { get; set; }

        /// <summary>
        /// 风险等级
        /// </summary>
        [XmlElement("risk_level")]
        public long RiskLevel { get; set; }
    }
}
