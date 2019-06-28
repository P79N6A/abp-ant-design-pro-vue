﻿using System;
using System.Xml.Serialization;

namespace Niue.Alipay.Domain
{
    /// <summary>
    /// KoubeiMarketingDataAlisisReportQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiMarketingDataAlisisReportQueryModel : AopObject
    {
        /// <summary>
        /// 报表唯一标识
        /// </summary>
        [XmlElement("report_uk")]
        public string ReportUk { get; set; }
    }
}
