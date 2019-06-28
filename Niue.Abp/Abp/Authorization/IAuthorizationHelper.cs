using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Niue.Abp.Abp.Authorization
{
    public interface IAuthorizationHelper
    {
        Task AuthorizeAsync(IEnumerable<IAbpAuthorizeAttribute> authorizeAttributes);

        Task AuthorizeAsync(MethodInfo methodInfo);
    }
}