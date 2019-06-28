﻿using System.Collections.Generic;
using System.Xml.Serialization;
using Niue.Alipay.Domain;

namespace Niue.Alipay.Response
{
    /// <summary>
    /// AlipayMobilePublicAccountQueryResponse.
    /// </summary>
    public class AlipayMobilePublicAccountQueryResponse : AopResponse
    {
        /// <summary>
        /// 结果码
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// 菜单唯一标识
        /// </summary>
        [XmlElement("menu_key")]
        public string MenuKey { get; set; }

        /// <summary>
        /// 结果描述
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 绑定账户列表
        /// </summary>
        [XmlArray("public_bind_accounts")]
        [XmlArrayItem("public_bind_account")]
        public List<PublicBindAccount> PublicBindAccounts { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [XmlElement("remark")]
        public string Remark { get; set; }
    }
}
