﻿using Niue.Abp.Abp.Configuration.Startup;
using Niue.Abp.Abp.MultiTenancy;
using Niue.Abp.Abp.Runtime.Remoting;

namespace Niue.Abp.Abp.Runtime.Session
{
    /// <summary>
    /// Implements null object pattern for <see cref="IAbpSession"/>.
    /// </summary>
    public class NullAbpSession : AbpSessionBase
    {
        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static NullAbpSession Instance { get; } = new NullAbpSession();

        /// <inheritdoc/>
        public override long? UserId => null;

        /// <inheritdoc/>
        public override int? TenantId => null;

        public override MultiTenancySides MultiTenancySide => MultiTenancySides.Tenant;

        public override long? ImpersonatorUserId => null;

        public override int? ImpersonatorTenantId => null;

        private NullAbpSession() 
            : base(new MultiTenancyConfig(), new DataContextAmbientScopeProvider<SessionOverride>(new CallContextAmbientDataContext()))
        {

        }
    }
}