﻿using System.Xml.Serialization;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// KoubeiQualityTestCloudacptCheckresultSubmitResponse.
    /// </summary>
    public class KoubeiQualityTestCloudacptCheckresultSubmitResponse : AopResponse
    {
        /// <summary>
        /// 活动id
        /// </summary>
        [XmlElement("activity_id")]
        public string ActivityId { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        [XmlElement("batch_id")]
        public string BatchId { get; set; }
    }
}
