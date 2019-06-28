using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Niue.Alipay.Domain
{
    /// <summary>
    /// KoubeiShopPicModifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiShopPicModifyModel : AopObject
    {
        /// <summary>
        /// 环境图名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 适用的门店列表
        /// </summary>
        [XmlArray("shop_ids")]
        [XmlArrayItem("string")]
        public List<string> ShopIds { get; set; }

        /// <summary>
        /// 店铺图片id
        /// </summary>
        [XmlElement("shop_pic_id")]
        public string ShopPicId { get; set; }
    }
}
