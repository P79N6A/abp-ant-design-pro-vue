using System.Collections.Generic;
using System.Xml.Serialization;
using Niue.Alipay.Domain;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayEcapiprodDrawndnRepaymentrecordQueryResponse.
    /// </summary>
    public class AlipayEcapiprodDrawndnRepaymentrecordQueryResponse : AopResponse
    {
        /// <summary>
        /// 还款流水
        /// </summary>
        [XmlArray("repayment_records")]
        [XmlArrayItem("repayment_records")]
        public List<RepaymentRecords> RepaymentRecords { get; set; }

        /// <summary>
        /// 唯一标识这次请求
        /// </summary>
        [XmlElement("request_id")]
        public string RequestId { get; set; }
    }
}
