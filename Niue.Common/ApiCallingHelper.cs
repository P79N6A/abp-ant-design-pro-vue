using System.IO;
using System.Net;
using System.Text;

namespace Niue.Common
{
    /// <summary>
    /// 接口调用辅助类
    /// </summary>
    public static class ApiCallingHelper
    {
        /// <summary>
        /// POST请求
        /// </summary>
        /// <param name="url">接口地址</param>
        /// <param name="param">参数</param>
        /// <param name="contentType">请求参数类型</param>
        /// <returns></returns>
        public static string Post(string url, string param, string contentType = "application/json")
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = contentType;
            var bytes = new UTF8Encoding().GetBytes(param);
            request.ContentLength = bytes.Length;
            var requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8")))
                    {
                        var readToEnd = streamReader.ReadToEnd();
                        return readToEnd;
                    }
                }
            }
        }
    }
}
