using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity;
using Niue.Abp.Abp.Domain.Entities;
using Niue.Abp.Abp.Domain.Entities.Auditing;

namespace Niue.Abp.Zero.Abp.Zero.Authorization.Roles
{
    /// <summary>
    /// Base class for role.
    /// </summary>
    [Table("AbpRoles")]
    public abstract class AbpRoleBase : FullAuditedEntity<int>, IRole<int>, IMayHaveTenant
    {
        /// <summary>
        /// Maximum length of the <see cref="Name"/> property.
        /// </summary>
        public const int MaxNameLength = 32;

        /// <summary>
        /// Tenant's Id, if this role is a tenant-level role. Null, if not.
        /// </summary>
        public virtual int? TenantId { get; set; }

        /// <summary>
        /// Unique name of this role.
        /// </summary>
        [Required]
        [StringLength(MaxNameLength)]
        public virtual string Name { get; set; }
    }
}