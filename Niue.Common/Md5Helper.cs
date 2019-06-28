using System;
using System.Security.Cryptography;
using System.Text;

namespace Niue.Common
{
    public static class Md5Helper
    {
        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Encrypt(string password)
        {
            var bytes = Encoding.Default.GetBytes(password);
            HashAlgorithm md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }

        /// <summary>
        /// sha1加密
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Sha1Encrypt(string key)
        {
            var md5 = new MD5CryptoServiceProvider();
            var bytes = Encoding.Default.GetBytes(key);
            var hash = md5.ComputeHash(bytes, 0, bytes.Length);
            md5.Clear();
            (md5 as IDisposable).Dispose();
            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// 微信sha1加密
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Sha1WeChat(string key)
        {
            var bytes = Encoding.UTF8.GetBytes(key);
            var sha1CryptoServiceProvider = new SHA1CryptoServiceProvider();
            var hash = sha1CryptoServiceProvider.ComputeHash(bytes);
            sha1CryptoServiceProvider.Clear();
            // 注意，不能用这个
            //string output = Convert.ToBase64String(temp2);
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}
