using System.Xml.Serialization;
using Niue.Alipay.Domain;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// KoubeiMarketingCampaignActivityQueryResponse.
    /// </summary>
    public class KoubeiMarketingCampaignActivityQueryResponse : AopResponse
    {
        /// <summary>
        /// 活动详情
        /// </summary>
        [XmlElement("camp_detail")]
        public CampDetail CampDetail { get; set; }
    }
}
