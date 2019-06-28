using System.Xml.Serialization;
using Niue.Alipay.Domain;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayMicropayOrderConfirmpayurlGetResponse.
    /// </summary>
    public class AlipayMicropayOrderConfirmpayurlGetResponse : AopResponse
    {
        /// <summary>
        /// SinglePayDetail信息
        /// </summary>
        [XmlElement("single_pay_detail")]
        public SinglePayDetail SinglePayDetail { get; set; }
    }
}
