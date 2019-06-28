using Niue.WeChat.Core.Entities.JsonResult;

namespace Niue.WeChat.PublicAccounts.AdvancedAPIs.Url.ShortUrlJson
{
    /// <summary>
    /// ShortUrl返回结果
    /// </summary>
    public class ShortUrlResult : WxJsonResult
    {
        public string short_url { get; set; }
    }
}
