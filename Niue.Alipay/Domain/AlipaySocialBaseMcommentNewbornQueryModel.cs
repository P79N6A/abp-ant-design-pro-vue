using System;
using System.Xml.Serialization;

namespace Niue.Alipay.Domain
{
    /// <summary>
    /// AlipaySocialBaseMcommentNewbornQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipaySocialBaseMcommentNewbornQueryModel : AopObject
    {
        /// <summary>
        /// 支付宝userId
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
