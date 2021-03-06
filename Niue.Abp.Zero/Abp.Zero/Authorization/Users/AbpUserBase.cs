using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity;
using Niue.Abp.Abp;
using Niue.Abp.Abp.Domain.Entities;
using Niue.Abp.Abp.Domain.Entities.Auditing;

namespace Niue.Abp.Zero.Abp.Zero.Authorization.Users
{
    /// <summary>
    /// Base class for user.
    /// </summary>
    [Table("AbpUsers")]
    public abstract class AbpUserBase : FullAuditedEntity<long>, IUser<long>, IMayHaveTenant
    {
        /// <summary>
        /// Maximum length of the <see cref="UserName"/> property.
        /// </summary>
        public const int MaxUserNameLength = 32;

        /// <summary>
        /// Maximum length of the <see cref="EmailAddress"/> property.
        /// </summary>
        public const int MaxEmailAddressLength = 256;

        /// <summary>
        /// User name.
        /// User name must be unique for it's tenant.
        /// </summary>
        [Required]
        [StringLength(MaxUserNameLength)]
        public virtual string UserName { get; set; }

        /// <summary>
        /// Tenant Id of this user.
        /// </summary>
        public virtual int? TenantId { get; set; }

        /// <summary>
        /// Email address of the user.
        /// Email address must be unique for it's tenant.
        /// </summary>
        [Required]
        [StringLength(MaxEmailAddressLength)]
        public virtual string EmailAddress { get; set; }

        /// <summary>
        /// The last time this user entered to the system.
        /// </summary>
        public virtual DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// Creates <see cref="UserIdentifier"/> from this User.
        /// </summary>
        /// <returns></returns>
        public virtual UserIdentifier ToUserIdentifier()
        {
            return new UserIdentifier(TenantId, Id);
        }
    }
}