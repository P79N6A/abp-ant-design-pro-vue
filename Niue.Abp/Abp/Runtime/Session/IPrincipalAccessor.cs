using System.Security.Claims;

namespace Niue.Abp.Abp.Runtime.Session
{
    public interface IPrincipalAccessor
    {
        ClaimsPrincipal Principal { get; }
    }
}
