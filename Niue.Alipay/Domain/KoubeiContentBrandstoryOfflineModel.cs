using System;
using System.Xml.Serialization;

namespace Niue.Alipay.Domain
{
    /// <summary>
    /// KoubeiContentBrandstoryOfflineModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiContentBrandstoryOfflineModel : AopObject
    {
        /// <summary>
        /// 需要下架的品牌故事id
        /// </summary>
        [XmlElement("brand_story_id")]
        public string BrandStoryId { get; set; }
    }
}
