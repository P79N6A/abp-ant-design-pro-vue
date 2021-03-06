﻿using System;
using System.Xml.Serialization;

namespace Niue.Alipay.Domain
{
    /// <summary>
    /// KoubeiContentArticleDeleteModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiContentArticleDeleteModel : AopObject
    {
        /// <summary>
        /// 达人说文章id
        /// </summary>
        [XmlElement("article_id")]
        public string ArticleId { get; set; }
    }
}
