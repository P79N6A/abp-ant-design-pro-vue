﻿using System.Xml.Serialization;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayMarketingCardTemplateModifyResponse.
    /// </summary>
    public class AlipayMarketingCardTemplateModifyResponse : AopResponse
    {
        /// <summary>
        /// 模板ID
        /// </summary>
        [XmlElement("template_id")]
        public string TemplateId { get; set; }
    }
}
