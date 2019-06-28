using Niue.Abp.Abp.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace Niue.Web.Handlers
{
    /// <summary>
    /// UploadBase64Handler 的摘要说明
    /// </summary>
    public class UploadBase64Handler : IHttpHandler
    {

        private HttpContext _context;

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";
            _context = context;
            var action = _context.Request.Form["action"];
            switch (action)
            {
                case "UploadImageBase64":
                    UploadImageBase64();
                    break;

            }
            _context.Response.End();
        }
        private void UploadImageBase64()
        {

            //将base64转为图片
            var base64 = _context.Request.Form["base64"];

            var size = 2; //默认图片大小为2M
            var imagePurpose = _context.Request.Form["purpose"]; //图片类型
            var path = "/Upload/Images/";

            if (!string.IsNullOrWhiteSpace(imagePurpose))
            {
                switch (imagePurpose.ToLower())
                {
                    //TODO: 规定文件大小并分配不同的路径
                    case "appuserface":
                        size = 1;
                        path += "AppUserFace/";
                        break;
                    case "businesspartyface":
                        size = 1;
                        path += "BusinessPartyFace/";
                        break;
                    case "businesspartyposter":
                        size = 1;
                        path += "BusinessPartyPoster/";
                        break;
                    case "universitypartyface":
                        size = 1;
                        path += "UniversityPartyFace/";
                        break;
                    case "universitypartyposter":
                        size = 1;
                        path += "UniversityPartyPoster/";
                        break;
                    default:
                        size = 2;
                        path += "Other/";
                        break;
                }
            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            try
            {
                string filename = Guid.NewGuid().ToString().Replace("-", "") + ".jpeg";
                var extensionStartIndex = base64.IndexOf("/", StringComparison.Ordinal);
                var extensionEndIndex = base64.IndexOf(";", StringComparison.Ordinal) + 1;
                var extension = base64.Substring(extensionStartIndex, extensionEndIndex - extensionStartIndex);
                if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
                {
                    _context.Response.Write(new FileUploadResult
                    {
                        Code = 2,
                        Message = "文件格式错误，请重新选择格式为*.jpg/*.jpeg/*.png格式的图片上传。",
                        Data = extension
                    }.ToJsonString());
                    return;
                }
                var index = base64.IndexOf("base64", StringComparison.Ordinal) + 7;
                if (index > 7)
                {
                    base64 = base64.Substring(index);
                }
                var content = Convert.FromBase64String(base64);
                var image = System.Drawing.Image.FromStream(new MemoryStream(content));
                image.Save(path + filename, ImageFormat.Jpeg);
                _context.Response.Write(
                  new FileUploadResult { Code = 0, Message = "上传成功！", Data = path + filename }.ToJsonString());
            }
            catch (Exception exception)
            {

                _context.Response.Write(new FileUploadResult
                {
                    Code = -1,
                    Message = "保存失败！服务器内部错误。",
                    Data = exception.ToString()
                }.ToJsonString());
            }
        }

        public bool IsReusable => false;
    }
}