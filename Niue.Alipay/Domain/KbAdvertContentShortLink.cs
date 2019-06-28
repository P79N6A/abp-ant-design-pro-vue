using System;
using System.Xml.Serialization;

namespace Niue.Alipay.Domain
{
    /// <summary>
    /// KbAdvertContentShortLink Data Structure.
    /// </summary>
    [Serializable]
    public class KbAdvertContentShortLink : AopObject
    {
        /// <summary>
        /// 链接地址
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }
    }
}
