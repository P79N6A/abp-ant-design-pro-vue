using System.Xml.Serialization;
using Niue.Alipay.Domain;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayUserAccountGetResponse.
    /// </summary>
    public class AlipayUserAccountGetResponse : AopResponse
    {
        /// <summary>
        /// 支付宝用户账户信息
        /// </summary>
        [XmlElement("alipay_account")]
        public AlipayAccount AlipayAccount { get; set; }
    }
}
