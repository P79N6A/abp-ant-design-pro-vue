using System.Xml.Serialization;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayOfflineMarketingVoucherCodeUploadResponse.
    /// </summary>
    public class AlipayOfflineMarketingVoucherCodeUploadResponse : AopResponse
    {
        /// <summary>
        /// 码库id
        /// </summary>
        [XmlElement("code_inventory_id")]
        public string CodeInventoryId { get; set; }
    }
}
