using System;
using System.Xml.Serialization;

namespace Niue.Alipay.Domain
{
    /// <summary>
    /// KoubeiShopDishDeleteModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiShopDishDeleteModel : AopObject
    {
        /// <summary>
        /// 菜品id
        /// </summary>
        [XmlElement("dish_id")]
        public string DishId { get; set; }
    }
}
