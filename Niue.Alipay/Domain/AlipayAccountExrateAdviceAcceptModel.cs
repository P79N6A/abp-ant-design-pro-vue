using System;
using System.Xml.Serialization;

namespace Niue.Alipay.Domain
{
    /// <summary>
    /// AlipayAccountExrateAdviceAcceptModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayAccountExrateAdviceAcceptModel : AopObject
    {
        /// <summary>
        /// 交易请求对象内容
        /// </summary>
        [XmlElement("advice")]
        public AdviceVO Advice { get; set; }
    }
}
