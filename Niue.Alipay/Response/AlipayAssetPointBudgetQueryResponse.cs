﻿using System.Xml.Serialization;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayAssetPointBudgetQueryResponse.
    /// </summary>
    public class AlipayAssetPointBudgetQueryResponse : AopResponse
    {
        /// <summary>
        /// 还可以发放的集分宝个数
        /// </summary>
        [XmlElement("budget_amount")]
        public long BudgetAmount { get; set; }
    }
}
