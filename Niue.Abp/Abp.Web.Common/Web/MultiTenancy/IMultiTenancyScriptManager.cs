namespace Niue.Abp.Abp.Web.Common.Web.MultiTenancy
{
    /// <summary>
    /// Used to create client scripts for multi-tenancy.
    /// </summary>
    public interface IMultiTenancyScriptManager
    {
        string GetScript();
    }
}