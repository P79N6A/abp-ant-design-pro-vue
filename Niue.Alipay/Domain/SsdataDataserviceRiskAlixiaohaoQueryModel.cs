﻿using System;
using System.Xml.Serialization;

namespace Niue.Alipay.Domain
{
    /// <summary>
    /// SsdataDataserviceRiskAlixiaohaoQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class SsdataDataserviceRiskAlixiaohaoQueryModel : AopObject
    {
        /// <summary>
        /// 电话号码
        /// </summary>
        [XmlElement("mobile_no")]
        public string MobileNo { get; set; }
    }
}
