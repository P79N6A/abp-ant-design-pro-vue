using System.Xml.Serialization;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayOpenPublicPartnerMenuQueryResponse.
    /// </summary>
    public class AlipayOpenPublicPartnerMenuQueryResponse : AopResponse
    {
        /// <summary>
        /// 服务窗菜单
        /// </summary>
        [XmlElement("public_menu")]
        public string PublicMenu { get; set; }
    }
}
