using System.Text.RegularExpressions;

namespace Niue.Common
{
    public static class RegVerifyHelper
    {
        /// <summary>
        /// 手机号验证
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsMobile(string str)
        {
            return new Regex(@"^1[3|4|5|7|8][0-9]\d{8}$").IsMatch(str);
        }

        /// <summary>
        /// 电子邮箱验证
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmailAddress(string str)
        {
            return new Regex(@"^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$").IsMatch(str);
        }

        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsIp(string str)
        {
            return new Regex(@"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$").IsMatch(str);
        }
    }
}
