using System.Collections.Generic;
using System.Xml.Serialization;
using Niue.Alipay.Domain;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayEcapiprodDrawndnPaymentscheduleGetResponse.
    /// </summary>
    public class AlipayEcapiprodDrawndnPaymentscheduleGetResponse : AopResponse
    {
        /// <summary>
        /// 返回的支用还款计划集合
        /// </summary>
        [XmlArray("payment_schedules")]
        [XmlArrayItem("payment_schedule")]
        public List<PaymentSchedule> PaymentSchedules { get; set; }

        /// <summary>
        /// 唯一标识这次请求
        /// </summary>
        [XmlElement("request_id")]
        public string RequestId { get; set; }
    }
}
