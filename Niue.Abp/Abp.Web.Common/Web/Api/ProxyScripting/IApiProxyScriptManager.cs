namespace Niue.Abp.Abp.Web.Common.Web.Api.ProxyScripting
{
    public interface IApiProxyScriptManager
    {
        string GetScript(ApiProxyGenerationOptions options);
    }
}