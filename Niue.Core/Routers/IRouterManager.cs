using System.Collections.Generic;
using System.Threading.Tasks;
using Niue.Abp.Abp.Domain.Services;

namespace Niue.Core.Routers
{
    public interface IRouterManager : IDomainService
    {
        Task<List<Router>> GetRouters();
    }
}
