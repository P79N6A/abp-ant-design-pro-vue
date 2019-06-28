using System.Collections.Generic;
using System.Xml.Serialization;
using Niue.Alipay.Domain;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayEcoMycarParkingCardbarcodeCreateResponse.
    /// </summary>
    public class AlipayEcoMycarParkingCardbarcodeCreateResponse : AopResponse
    {
        /// <summary>
        /// 停车车卡对应二维码列表
        /// </summary>
        [XmlArray("qrcodes")]
        [XmlArrayItem("q_rcode")]
        public List<QRcode> Qrcodes { get; set; }
    }
}
