﻿using System.Xml.Serialization;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// SsdataDataserviceRiskAlixiaohaoQueryResponse.
    /// </summary>
    public class SsdataDataserviceRiskAlixiaohaoQueryResponse : AopResponse
    {
        /// <summary>
        /// 是否阿里小号
        /// </summary>
        [XmlElement("is_alixiaohao")]
        public bool IsAlixiaohao { get; set; }
    }
}
