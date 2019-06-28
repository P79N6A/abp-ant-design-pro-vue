using System;
using System.Xml.Serialization;

namespace Niue.Alipay.Domain
{
    /// <summary>
    /// AlipayEcoMycarDataserviceMaintainvehicleShareModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayEcoMycarDataserviceMaintainvehicleShareModel : AopObject
    {
        /// <summary>
        /// 车辆ID
        /// </summary>
        [XmlElement("vid")]
        public string Vid { get; set; }
    }
}
