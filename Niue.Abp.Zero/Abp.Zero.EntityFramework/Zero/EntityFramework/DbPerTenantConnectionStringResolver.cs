﻿using Niue.Abp.Abp.Configuration.Startup;
using Niue.Abp.Abp.Domain.Uow;
using Niue.Abp.Abp.Extensions;
using Niue.Abp.Abp.MultiTenancy;
using Niue.Abp.Abp.Runtime.Session;
using Niue.Abp.Zero.Abp.Zero.MultiTenancy;

namespace Niue.Abp.Zero.Abp.Zero.EntityFramework.Zero.EntityFramework
{
    /// <summary>
    /// Implements <see cref="IDbPerTenantConnectionStringResolver"/> to dynamically resolve
    /// connection string for a multi tenant application.
    /// </summary>
    public class DbPerTenantConnectionStringResolver : DefaultConnectionStringResolver, IDbPerTenantConnectionStringResolver
    {
        /// <summary>
        /// Reference to the session.
        /// </summary>
        public IAbpSession AbpSession { get; set; }

        private readonly ICurrentUnitOfWorkProvider _currentUnitOfWorkProvider;
        private readonly ITenantCache _tenantCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbPerTenantConnectionStringResolver"/> class.
        /// </summary>
        public DbPerTenantConnectionStringResolver(
            IAbpStartupConfiguration configuration,
            ICurrentUnitOfWorkProvider currentUnitOfWorkProvider,
            ITenantCache tenantCache)
            : base(
                  configuration)
        {
            _currentUnitOfWorkProvider = currentUnitOfWorkProvider;
            _tenantCache = tenantCache;

            AbpSession = NullAbpSession.Instance;
        }

        public override string GetNameOrConnectionString(ConnectionStringResolveArgs args)
        {
            if (args.MultiTenancySide == MultiTenancySides.Host)
            {
                return GetNameOrConnectionString(new DbPerTenantConnectionStringResolveArgs(null, args));
            }

            return GetNameOrConnectionString(new DbPerTenantConnectionStringResolveArgs(GetCurrentTenantId(), args));
        }

        public virtual string GetNameOrConnectionString(DbPerTenantConnectionStringResolveArgs args)
        {
            if (args.TenantId == null)
            {
                //Requested for host
                return base.GetNameOrConnectionString(args);
            }

            var tenantCacheItem = _tenantCache.Get(args.TenantId.Value);
            if (tenantCacheItem.ConnectionString.IsNullOrEmpty())
            {
                //Tenant has not dedicated database
                return base.GetNameOrConnectionString(args);
            }

            return tenantCacheItem.ConnectionString;
        }

        protected virtual int? GetCurrentTenantId()
        {
            return _currentUnitOfWorkProvider.Current != null
                ? _currentUnitOfWorkProvider.Current.GetTenantId()
                : AbpSession.TenantId;
        }
    }
}
