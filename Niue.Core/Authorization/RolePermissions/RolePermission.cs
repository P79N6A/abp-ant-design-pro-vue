using System.ComponentModel.DataAnnotations;
using Niue.Abp.Abp.Domain.Entities.Auditing;
using Niue.Core.Routers;

namespace Niue.Core.Authorization.RolePermissions
{
    /// <summary>
    /// 角色权限
    /// </summary>
    public class RolePermission : FullAuditedEntity<long>
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public virtual int RoleId { get; set; }
        /// <summary>
        /// 路由权限
        /// </summary>
        public virtual Router Router { get; set; }
        /// <summary>
        /// 二级权限 Json
        /// </summary>
        public virtual string Actions { get; set; }
        /// <summary>
        /// 是否保留，用于初始化数据
        /// </summary>
        public virtual bool IsKeep { get; set; }
    }
}
