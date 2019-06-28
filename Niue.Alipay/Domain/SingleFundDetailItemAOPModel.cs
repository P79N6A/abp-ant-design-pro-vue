﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Niue.Alipay.Domain
{
    /// <summary>
    /// SingleFundDetailItemAOPModel Data Structure.
    /// </summary>
    [Serializable]
    public class SingleFundDetailItemAOPModel : AopObject
    {
        /// <summary>
        /// 批次资金明细模型列表
        /// </summary>
        [XmlArray("batch_fund_item_model_list")]
        [XmlArrayItem("batch_fund_item_a_o_p_model")]
        public List<BatchFundItemAOPModel> BatchFundItemModelList { get; set; }

        /// <summary>
        /// 消费记录主记录
        /// </summary>
        [XmlElement("consume_record")]
        public ConsumeRecordAOPModel ConsumeRecord { get; set; }
    }
}
