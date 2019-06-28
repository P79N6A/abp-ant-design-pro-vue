using Niue.WeChat.Core.Entities.JsonResult;

namespace Niue.WeChat.PublicAccounts.AdvancedAPIs.MerChant.Picture
{
    /// <summary>
    /// 上传图片返回结果
    /// </summary>
    public class PictureResult : WxJsonResult
    {
        /// <summary>
        /// 图片Url
        /// </summary>
        public string image_url { get; set; }
    }
}

