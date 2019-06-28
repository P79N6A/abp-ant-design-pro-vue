using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Niue.Abp.Abp.Domain.Repositories;
using Niue.Abp.Abp.UI;
using Niue.Application.Routers.Dto;
using Niue.Core.Enums;
using Niue.Core.Routers;
using Niue.Core.Users;

namespace Niue.Application.Routers
{
    public class RouterAppService : NiueAppServiceBase, IRouterAppService
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly IRouterManager _routerManager;

        public RouterAppService(IRepository<User, long> userRepository, IRouterManager routerManager)
        {
            _userRepository = userRepository;
            _routerManager = routerManager;
        }

        public async Task<List<RouterDto>> GetRouters()
        {
            var currentUserId = AbpSession.UserId;
            if (currentUserId == null)
            {
                throw new UserFriendlyException("当前用户会话失效，请重新登录。");
            }
            var currentUser = await _userRepository.FirstOrDefaultAsync(o => o.Id == currentUserId.Value);
            if (currentUser == null)
            {
                throw new UserFriendlyException("当前用户会话失效，请重新登录。");
            }
            var routerDtos = new List<RouterDto>();
            var routerDto = new RouterDto();
            routerDto.Title = "首页";
            routerDto.Key = "";
            routerDto.Name = "index";
            routerDto.Component = "BasicLayout";
            if (currentUser.UserType == EnumUserType.Agent)
            {
                routerDto.Redirect = "/console/workplace";
            }
            else
            {
                routerDto.Redirect = "/console/dashboard";
            }
            routerDto.Children = new List<RouterDto>();
            var routers = await _routerManager.GetRouters();
            var parentRouters = routers.Where(o => string.IsNullOrWhiteSpace(o.ParentKey)).OrderBy(o => o.Sort).ToList();
            foreach (var parentRouter in parentRouters)
            {
                var parentRouterDto = new RouterDto();
                parentRouterDto.Title = parentRouter.Name;
                parentRouterDto.Key = parentRouter.Key;
                parentRouterDto.Component = parentRouter.Component;
                parentRouterDto.Icon = parentRouter.Icon;
                parentRouterDto.Children = new List<RouterDto>();
                var children = routers.Where(o => o.ParentKey == parentRouter.Key).OrderBy(o => o.Sort).ToList();
                foreach (var child in children)
                {
                    var childRouterDto = new RouterDto();
                    childRouterDto.Title = child.Name;
                    childRouterDto.Key = child.Key;
                    childRouterDto.Icon = child.Icon;
                    parentRouterDto.Children.Add(childRouterDto);
                }
                routerDto.Children.Add(parentRouterDto);
            }
            routerDtos.Add(routerDto);
            return routerDtos;
        }
    }
}
