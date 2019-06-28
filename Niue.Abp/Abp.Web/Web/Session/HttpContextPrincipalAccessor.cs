using System.Security.Claims;
using System.Web;
using Niue.Abp.Abp.Runtime.Session;

namespace Niue.Abp.Abp.Web.Web.Session
{
    public class HttpContextPrincipalAccessor : DefaultPrincipalAccessor
    {
        public override ClaimsPrincipal Principal => HttpContext.Current?.User as ClaimsPrincipal ?? base.Principal;
    }
}
