﻿using System;
using System.Xml.Serialization;

namespace Niue.Alipay.Domain
{
    /// <summary>
    /// AlipayDataDataserviceYuebaolqdDetailQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayDataDataserviceYuebaolqdDetailQueryModel : AopObject
    {
        /// <summary>
        /// 服务入参，格式为yyyymmdd
        /// </summary>
        [XmlElement("report_date")]
        public string ReportDate { get; set; }
    }
}
