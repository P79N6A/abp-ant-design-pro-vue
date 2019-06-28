using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Niue.Abp.Abp.Extensions;
using Niue.Abp.Zero.Abp.Zero.Authorization.Users;
using Niue.Core.Enums;

namespace Niue.Core.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        [Required]
        [StringLength(20)]
        [Description("手机号码")]
        public virtual string Mobile { get; set; }

        [Description("用户类型")]
        public virtual EnumUserType UserType { get; set; }

        [Description("微信OpenId")]
        public virtual string WxOpenId { get; set; }

        [StringLength(20)]
        [Description("身份证号")]
        public virtual string IdentificationNumber { get; set; }

        [Description("身份证照片")]
        public virtual string IdentificationPhoto { get; set; }

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress, string password)
        {
            return new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                Mobile = AdminUserName,
                EmailAddress = emailAddress,
                Password = new PasswordHasher().HashPassword(password)
            };
        }
    }
}