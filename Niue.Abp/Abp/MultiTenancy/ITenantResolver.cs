namespace Niue.Abp.Abp.MultiTenancy
{
    public interface ITenantResolver
    {
        int? ResolveTenantId();
    }
}