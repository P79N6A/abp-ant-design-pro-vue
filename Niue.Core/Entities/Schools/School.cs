using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Niue.Abp.Abp.Domain.Entities.Auditing;
using Niue.Core.Entities.Agents;
using Niue.Core.Entities.Cities;

namespace Niue.Core.Entities.Schools
{
    [Description("学校")]
    public class School : FullAuditedEntity
    {
        [Required]
        [Description("所属用户Id")]
        public virtual long UserId { get; set; }

        [Required]
        [Description("所属城市")]
        public virtual City City { get; set; }

        [Required]
        [Description("所属代理商")]
        public virtual Agent Agent { get; set; }

        [Required]
        [StringLength(10)]
        [Description("城市学校编码")]
        public virtual string Code { get; set; }

        [Required]
        [StringLength(32)]
        [Description("名称")]
        public virtual string Name { get; set; }

        [Description("虚拟路径")]
        public virtual string VirtualUrl { get; set; }
    }
}
