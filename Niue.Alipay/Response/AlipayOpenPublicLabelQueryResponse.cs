using System.Collections.Generic;
using System.Xml.Serialization;
using Niue.Alipay.Domain;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayOpenPublicLabelQueryResponse.
    /// </summary>
    public class AlipayOpenPublicLabelQueryResponse : AopResponse
    {
        /// <summary>
        /// 该服务窗拥有的标签列表
        /// </summary>
        [XmlArray("label_list")]
        [XmlArrayItem("public_label")]
        public List<PublicLabel> LabelList { get; set; }
    }
}
