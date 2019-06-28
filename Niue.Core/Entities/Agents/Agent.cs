using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Niue.Abp.Abp.Domain.Entities.Auditing;

namespace Niue.Core.Entities.Agents
{
    [Description("代理商")]
    public class Agent : FullAuditedEntity
    {
        [Required]
        [Description("所属用户Id")]
        public virtual long UserId { get; set; }

        [Required]
        [StringLength(32)]
        [Description("名称")]
        public virtual string Name { get; set; }

        [Description("授权次数（设备基础数量）")]
        public virtual int LicenseCount { get; set; }
    }
}
