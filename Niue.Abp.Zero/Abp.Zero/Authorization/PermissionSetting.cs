﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Niue.Abp.Abp.Domain.Entities;
using Niue.Abp.Abp.Domain.Entities.Auditing;

namespace Niue.Abp.Zero.Abp.Zero.Authorization
{
    /// <summary>
    /// Used to grant/deny a permission for a role or user.
    /// </summary>
    [Table("AbpPermissions")]
    public abstract class PermissionSetting : CreationAuditedEntity<long>, IMayHaveTenant
    {
        /// <summary>
        /// Maximum length of the <see cref="Name"/> field.
        /// </summary>
        public const int MaxNameLength = 128;

        public virtual int? TenantId { get; set; }

        /// <summary>
        /// Unique name of the permission.
        /// </summary>
        [Required]
        [MaxLength(MaxNameLength)]
        public virtual string Name { get; set; }

        /// <summary>
        /// Is this role granted for this permission.
        /// Default value: true.
        /// </summary>
        public virtual bool IsGranted { get; set; }

        /// <summary>
        /// Creates a new <see cref="PermissionSetting"/> entity.
        /// </summary>
        protected PermissionSetting()
        {
            IsGranted = true;
        }
    }
}
