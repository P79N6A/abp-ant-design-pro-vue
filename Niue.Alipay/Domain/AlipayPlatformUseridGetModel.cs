using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Niue.Alipay.Domain
{
    /// <summary>
    /// AlipayPlatformUseridGetModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayPlatformUseridGetModel : AopObject
    {
        /// <summary>
        /// openId的列表
        /// </summary>
        [XmlArray("open_ids")]
        [XmlArrayItem("string")]
        public List<string> OpenIds { get; set; }
    }
}
