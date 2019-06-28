using System.Xml.Serialization;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipaySecurityProdAlipaySecurityProdTestResponse.
    /// </summary>
    public class AlipaySecurityProdAlipaySecurityProdTestResponse : AopResponse
    {
        /// <summary>
        /// ddd
        /// </summary>
        [XmlElement("admin")]
        public string Admin { get; set; }
    }
}
