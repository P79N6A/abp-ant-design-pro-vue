using System;
using System.ComponentModel.DataAnnotations.Schema;
using Niue.Abp.Abp.Domain.Entities.Auditing;
using Niue.Abp.Abp.MultiTenancy;

namespace Niue.Abp.Zero.Abp.Zero.Authorization.Users
{
    /// <summary>
    /// Represents a summary user
    /// </summary>
    [Table("AbpUserAccounts")]
    [MultiTenancySide(MultiTenancySides.Host)]
    public class UserAccount : FullAuditedEntity<long>
    {
        public virtual int? TenantId { get; set; }

        public virtual long UserId { get; set; }

        public virtual long? UserLinkId { get; set; }

        public virtual string UserName { get; set; }

        public virtual string EmailAddress { get; set; }

        public virtual DateTime? LastLoginTime { get; set; }
    }
}