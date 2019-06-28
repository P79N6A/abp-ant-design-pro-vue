using System.ComponentModel;

namespace Niue.Core.Enums
{
    public enum EnumResultCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 0,
        /// <summary>
        /// 异常
        /// </summary>
        [Description("异常")]
        Error = 1,
        /// <summary>
        /// 当前用户会话失效，请重新登录。
        /// </summary>
        [Description("当前用户会话失效，请重新登录。")]
        SessionInvalid = 2,
        #region 参数校验
        /// <summary>
        /// 用户名格式错误
        /// </summary>
        [Description("用户名格式错误")]
        UserNameError = 1001,
        /// <summary>
        /// 密码格式错误
        /// </summary>
        [Description("密码格式错误")]
        PasswordError = 1002,
        /// <summary>
        /// 姓名格式错误
        /// </summary>
        [Description("姓名格式错误")]
        NameError = 1003,
        /// <summary>
        /// 手机号格式错误
        /// </summary>
        [Description("手机号格式错误")]
        MobileError = 1004,
        /// <summary>
        /// 电子邮箱格式错误
        /// </summary>
        [Description("电子邮箱格式错误")]
        EmailAddressError = 1005,
        #endregion
        #region 用户相关
        /// <summary>
        /// 用户名已存在
        /// </summary>
        [Description("用户名已存在")]
        UserNameExists = 20101,
        /// <summary>
        /// 用户不存在
        /// </summary>
        [Description("用户不存在")]
        UserNotExists = 20102,
        #endregion
        #region 预留
        #endregion
    }
}
