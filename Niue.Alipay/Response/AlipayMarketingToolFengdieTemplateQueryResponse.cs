﻿using System.Collections.Generic;
using System.Xml.Serialization;
using Niue.Alipay.Domain;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayMarketingToolFengdieTemplateQueryResponse.
    /// </summary>
    public class AlipayMarketingToolFengdieTemplateQueryResponse : AopResponse
    {
        /// <summary>
        /// 开发者开发上传的H5模板列表
        /// </summary>
        [XmlArray("template")]
        [XmlArrayItem("fengdie_template")]
        public List<FengdieTemplate> Template { get; set; }
    }
}
