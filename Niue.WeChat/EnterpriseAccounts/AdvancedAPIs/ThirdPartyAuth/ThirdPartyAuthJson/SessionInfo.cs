using System.Collections.Generic;

namespace Niue.WeChat.EnterpriseAccounts.AdvancedAPIs.ThirdPartyAuth.ThirdPartyAuthJson
{
    public class SessionInfo
    {
        /// <summary>
        /// 允许进行授权的应用id，如1、2、3
        /// </summary>
        public List<string> appid { get; set; }
    }
}
