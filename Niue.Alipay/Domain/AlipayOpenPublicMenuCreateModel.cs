using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Niue.Alipay.Domain
{
    /// <summary>
    /// AlipayOpenPublicMenuCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenPublicMenuCreateModel : AopObject
    {
        /// <summary>
        /// 一级菜单数组，个数应为1~4个
        /// </summary>
        [XmlArray("button")]
        [XmlArrayItem("button_object")]
        public List<ButtonObject> Button { get; set; }
    }
}
