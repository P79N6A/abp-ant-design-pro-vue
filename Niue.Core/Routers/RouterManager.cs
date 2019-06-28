using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Niue.Abp.Abp.Domain.Repositories;

namespace Niue.Core.Routers
{
    public class RouterManager : IRouterManager
    {
        private readonly IRepository<Router> _routerRepository;

        public RouterManager(IRepository<Router> routerRepository)
        {
            _routerRepository = routerRepository;
        }

        public async Task<List<Router>> GetRouters()
        {
            var routers = await _routerRepository.GetAllListAsync();
            return routers.OrderBy(o => o.Sort).ToList();
        }
    }
}
