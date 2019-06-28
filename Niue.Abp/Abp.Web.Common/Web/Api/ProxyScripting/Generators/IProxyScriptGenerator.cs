using Niue.Abp.Abp.Web.Common.Web.Api.Modeling;

namespace Niue.Abp.Abp.Web.Common.Web.Api.ProxyScripting.Generators
{
    public interface IProxyScriptGenerator
    {
        string CreateScript(ApplicationApiDescriptionModel model);
    }
}