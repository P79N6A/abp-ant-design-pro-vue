using System.Xml.Serialization;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayMarketingCampaignDiscountBudgetCreateResponse.
    /// </summary>
    public class AlipayMarketingCampaignDiscountBudgetCreateResponse : AopResponse
    {
        /// <summary>
        /// 预算ID
        /// </summary>
        [XmlElement("budget_id")]
        public string BudgetId { get; set; }
    }
}
