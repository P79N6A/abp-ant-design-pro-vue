using System.Web;

namespace Niue.Abp.Abp.Web.Web.Localization
{
    public interface ICurrentCultureSetter
    {
        void SetCurrentCulture(HttpContext httpContext);
    }
}
