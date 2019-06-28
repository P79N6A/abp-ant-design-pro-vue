using System.Collections.Generic;
using System.Xml.Serialization;
using Niue.Alipay.Domain;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayCommerceCityfacilitatorFunctionQueryResponse.
    /// </summary>
    public class AlipayCommerceCityfacilitatorFunctionQueryResponse : AopResponse
    {
        /// <summary>
        /// 支持的功能列表
        /// </summary>
        [XmlArray("functions")]
        [XmlArrayItem("support_function")]
        public List<SupportFunction> Functions { get; set; }
    }
}
