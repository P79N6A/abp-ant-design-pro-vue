using System.Xml.Serialization;
using Niue.Alipay.Domain;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayMicropayOrderUnfreezeResponse.
    /// </summary>
    public class AlipayMicropayOrderUnfreezeResponse : AopResponse
    {
        /// <summary>
        /// 冻结订单详情结果
        /// </summary>
        [XmlElement("unfreeze_order_detail")]
        public UnfreezeOrderDetail UnfreezeOrderDetail { get; set; }
    }
}
