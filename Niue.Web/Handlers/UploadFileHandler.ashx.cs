using System;
using System.IO;
using System.Web;
using Niue.Abp.Abp.Json;

namespace Niue.Web.Handlers
{
    public class UploadFileHandler : IHttpHandler
    {
        private HttpContext _context;

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";
            _context = context;
            var action = _context.Request["action"];
            switch (action)
            {
                case "UploadImage":
                    UploadImage();
                    break;

            }
            _context.Response.End();
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        private void UploadImage()
        {
            var file = _context.Request.Files[0];
            var size = 2; //默认图片大小为2M
            var imagePurpose = _context.Request["purpose"]; //图片类型
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
                    case "identificationphoto":
                        size = 1;
                        path += "IdentificationPhoto/";
                        break;
                    case "studentcardphoto":
                        size = 1;
                        path += "StudentCardPhoto/";
                        break;
                    case "billboardimage":
                        size = 1;
                        path += "BillboardImage/";
                        break;
                    case "magazineposter":
                        size = 1;
                        path += "MagazinePoster/";
                        break;
                    case "clubfaceimage":
                        size = 1;
                        path += "ClubFaceImage/";
                        break;
                    case "clublogo":
                        size = 1;
                        path += "ClubLogo/";
                        break;
                    default:
                        size = 2;
                        path += "Other/";
                        break;
                }
            }
            if (file.ContentLength > 1024 * 1024 * size)
            {
                _context.Response.Write(new FileUploadResult
                {
                    Code = 1,
                    Message = "文件大小不能超过" + size + "M",
                    Data = file.ContentLength
                }.ToJsonString());
                return;
            }
            var extension = ("." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1]).ToLower();
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
            try
            {
                var mapPath = _context.Server.MapPath("~" + path);
                if (!Directory.Exists(mapPath))//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(mapPath);
                }
                var filename = Guid.NewGuid().ToString().Replace("-", "") + extension;
                file.SaveAs(mapPath + filename);
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


    public class FileUploadResult
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
