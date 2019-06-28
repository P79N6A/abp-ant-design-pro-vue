using System;
using System.Xml.Serialization;

namespace Niue.Alipay.Domain
{
    /// <summary>
    /// KoubeiShopPicDeleteModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiShopPicDeleteModel : AopObject
    {
        /// <summary>
        /// 店铺图片id
        /// </summary>
        [XmlElement("shop_pic_id")]
        public string ShopPicId { get; set; }
    }
}
