using Niue.Abp.Abp.Application.Services.Dto;
using Niue.Abp.Abp.AutoMapper.AutoMapper;
using Niue.Application.Roles.Dto;
using Niue.Core.Enums;
using Niue.Core.Users;

namespace Niue.Application.Users.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserDto : EntityDto<long>
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        public string Surname { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public virtual string Pwd { get; set; }

        public string FullName { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string EmailAddress { get; set; }

        public bool IsEmailConfirmed { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string PhoneNumber { get; set; }

        public bool IsPhoneNumberConfirmed { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public string LastLoginTime { get; set; }

        /// <summary>
        /// 状态：0-禁用，1-正常
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreationTime { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public RoleDto Role { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public virtual string Mobile { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public virtual EnumUserType UserType { get; set; }

        /// <summary>
        /// 微信OpenId
        /// </summary>
        public virtual string WxOpenId { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public virtual string IdentificationNumber { get; set; }

        /// <summary>
        /// 身份证照片
        /// </summary>
        public virtual string IdentificationPhoto { get; set; }
    }
}