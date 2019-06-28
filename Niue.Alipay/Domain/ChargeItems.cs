﻿using System;
using System.Xml.Serialization;

namespace Niue.Alipay.Domain
{
    /// <summary>
    /// ChargeItems Data Structure.
    /// </summary>
    [Serializable]
    public class ChargeItems : AopObject
    {
        /// <summary>
        /// 缴费项名称
        /// </summary>
        [XmlElement("item_name")]
        public string ItemName { get; set; }

        /// <summary>
        /// 缴费项金额
        /// </summary>
        [XmlElement("item_price")]
        public string ItemPrice { get; set; }
    }
}
