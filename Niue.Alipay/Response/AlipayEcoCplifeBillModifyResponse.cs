using System.Collections.Generic;
using System.Xml.Serialization;
using Niue.Alipay.Domain;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayEcoCplifeBillModifyResponse.
    /// </summary>
    public class AlipayEcoCplifeBillModifyResponse : AopResponse
    {
        /// <summary>
        /// 不允许修改（支付中或者支付完成）的账单明细条目列表
        /// </summary>
        [XmlArray("alive_bill_entry_list")]
        [XmlArrayItem("c_p_alive_bill_entry_set")]
        public List<CPAliveBillEntrySet> AliveBillEntryList { get; set; }
    }
}
