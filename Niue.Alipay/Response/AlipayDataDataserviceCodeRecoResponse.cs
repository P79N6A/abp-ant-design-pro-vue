using System.Xml.Serialization;
using Niue.Alipay.Domain;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayDataDataserviceCodeRecoResponse.
    /// </summary>
    public class AlipayDataDataserviceCodeRecoResponse : AopResponse
    {
        /// <summary>
        /// 识别结果
        /// </summary>
        [XmlElement("result")]
        public AlipayCodeRecoResult Result { get; set; }
    }
}
