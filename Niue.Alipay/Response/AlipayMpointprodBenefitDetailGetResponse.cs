﻿using System.Collections.Generic;
using System.Xml.Serialization;
using Niue.Alipay.Domain;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayMpointprodBenefitDetailGetResponse.
    /// </summary>
    public class AlipayMpointprodBenefitDetailGetResponse : AopResponse
    {
        /// <summary>
        /// 权益详情列表
        /// </summary>
        [XmlArray("benefit_infos")]
        [XmlArrayItem("benefit_info")]
        public List<BenefitInfo> BenefitInfos { get; set; }

        /// <summary>
        /// 响应码
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 响应描述
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }
    }
}
