using System.ComponentModel.DataAnnotations;
using Niue.Abp.Abp.Domain.Entities.Auditing;

namespace Niue.Core.Routers
{
    /// <summary>
    /// 路由
    /// </summary>
    public class Router : FullAuditedEntity
    {
        /// <summary>
        /// 路由唯一键
        /// </summary>
        [StringLength(50)]
        public virtual string Key { get; set; }
        /// <summary>
        /// 路由父级唯一键
        /// </summary>
        [StringLength(50)]
        public virtual string ParentKey { get; set; }
        /// <summary>
        /// 路由名称
        /// </summary>
        [StringLength(50)]
        public virtual string Name { get; set; }
        /// <summary>
        /// 路由组件
        /// </summary>
        [StringLength(50)]
        public virtual string Component { get; set; }
        /// <summary>
        /// 重定向地址，访问这个路由时，自定进行重定向
        /// </summary>
        public virtual string Redirect { get; set; }
        /// <summary>
        /// 路由在 menu 上显示的图标
        /// </summary>
        [StringLength(20)]
        public virtual string Icon { get; set; }
        /// <summary>
        /// 排序序号
        /// </summary>
        public virtual int Sort { get; set; }
        /// <summary>
        /// 是否保留，用于初始化数据
        /// </summary>
        public virtual bool IsKeep { get; set; }
    }
}
