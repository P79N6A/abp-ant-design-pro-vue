namespace Niue.Abp.Zero.Abp.Zero.MultiTenancy
{
    public interface IAbpZeroDbMigrator
    {
        void CreateOrMigrateForHost();

        void CreateOrMigrateForTenant(AbpTenantBase tenant);
    }
}
