using System.Collections.Generic;
using Niue.Abp.Abp.Application.Services.Dto;
using Niue.Core.Enums;

namespace Niue.Application.Sessions.Dto
{
    /// <summary>
    /// cms用户信息DTO
    /// </summary>
    public class UserInfoDto : EntityDto<long>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 状态：0-禁用，1-正常
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public EnumUserType UserType { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public UserInfoRoleDto Role { get; set; }
    }

    public class UserInfoRoleDto : EntityDto
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 角色描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 角色状态：0-禁用，1-正常
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 权限菜单
        /// </summary>
        public List<UserInfoRolePermissionDto> Permissions { get; set; }
    }

    public class UserInfoRolePermissionDto : EntityDto<long>
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 权限菜单Id
        /// </summary>
        public string PermissionId { get; set; }
        /// <summary>
        /// 权限菜单名称
        /// </summary>
        public string PermissionName { get; set; }
        /// <summary>
        /// 权限菜单Json
        /// </summary>
        public string Actions { get; set; }
        /// <summary>
        /// 权限菜单配置
        /// </summary>
        public List<UserInfoActionEntitySetDto> ActionEntitySet { get; set; }
    }

    public class UserInfoActionEntitySetDto
    {
        /// <summary>
        /// 菜单
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 默认选择
        /// </summary>
        public bool DefaultCheck { get; set; }
    }
}
