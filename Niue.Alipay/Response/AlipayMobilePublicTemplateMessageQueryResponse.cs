using System.Xml.Serialization;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayMobilePublicTemplateMessageQueryResponse.
    /// </summary>
    public class AlipayMobilePublicTemplateMessageQueryResponse : AopResponse
    {
        /// <summary>
        /// 结果值
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }
    }
}
