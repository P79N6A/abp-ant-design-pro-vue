using Niue.Abp.Abp.Domain.Uow;

namespace Niue.Abp.Zero.Abp.Zero.MultiTenancy
{
    /// <summary>
    /// Extends <see cref="IConnectionStringResolver"/> to
    /// get connection string for given tenant.
    /// </summary>
    public interface IDbPerTenantConnectionStringResolver : IConnectionStringResolver
    {
        /// <summary>
        /// Gets the connection string for given args.
        /// </summary>
        string GetNameOrConnectionString(DbPerTenantConnectionStringResolveArgs args);
    }
}
