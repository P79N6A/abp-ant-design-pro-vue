namespace Niue.Abp.Abp.MultiTenancy
{
    public interface ITenantResolveContributor
    {
        int? ResolveTenantId();
    }
}