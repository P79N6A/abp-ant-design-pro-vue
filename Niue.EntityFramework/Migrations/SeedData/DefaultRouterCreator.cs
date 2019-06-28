using System.Linq;
using Niue.Core.Authorization.RolePermissions;
using Niue.Core.Authorization.Roles;
using Niue.Core.Routers;
using Niue.EntityFramework.EntityFramework;

namespace Niue.EntityFramework.Migrations.SeedData
{
    public class DefaultRouterCreator
    {
        private readonly NiueDbContext _context;

        public DefaultRouterCreator(NiueDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            #region 添加路由数据
            AddRouterIfNotExists("console", "", "控制台", "RouteView", "", "dashboard", 100);
            AddRouterIfNotExists("dashboard", "console", "仪表盘", "", "", "", 101);
            AddRouterIfNotExists("workplace", "console", "工作台", "", "", "", 102);

            AddRouterIfNotExists("user-manager", "", "用户管理", "PageView", "", "user", 200);
            AddRouterIfNotExists("user", "user-manager", "用户", "", "", "", 201);
            AddRouterIfNotExists("user-role", "user-manager", "用户角色", "", "", "", 202);

            AddRouterIfNotExists("menu-manager", "", "菜单管理", "PageView", "", "bars", 300);
            AddRouterIfNotExists("menu", "menu-manager", "菜单", "", "", "", 301);

            AddRouterIfNotExists("role-manager", "", "角色管理", "PageView", "", "tag", 400);
            AddRouterIfNotExists("role", "role-manager", "角色", "", "", "", 401);
            AddRouterIfNotExists("role-menu", "role-manager", "角色菜单权限", "", "", "", 402);

            AddRouterIfNotExists("agent-manager", "", "代理商管理", "PageView", "", "shop", 1000);
            AddRouterIfNotExists("agent", "agent-manager", "代理商", "", "", "", 1001);

            AddRouterIfNotExists("school-manager", "", "学校管理", "PageView", "", "read", 1100);
            AddRouterIfNotExists("school", "school-manager", "学校", "", "", "", 1101);

            AddRouterIfNotExists("user-center", "", "用户中心", "PageView", "", "idcard", 9000);
            AddRouterIfNotExists("user-info", "user-center", "账户设置", "", "", "", 9001);
            AddRouterIfNotExists("update-password", "user-center", "修改密码", "", "", "", 9002);

            AddRouterIfNotExists("setting", "", "配置", "PageView", "", "setting", 9500);
            AddRouterIfNotExists("system-setting", "setting", "系统配置", "", "", "", 9501);

            ClearRouter();
            #endregion
        }

        private void AddRouterIfNotExists(string key, string parentKey, string name, string component, string redirect, string icon, int sort)
        {
            var router = _context.Routers.FirstOrDefault(o => o.ParentKey == parentKey && o.Key == key);
            if (router == null)
            {
                router = new Router();
                router.Key = key;
                router.ParentKey = parentKey;
                router.Name = name;
                router.Component = component;
                router.Redirect = redirect;
                router.Icon = icon;
                router.Sort = sort;
                router.IsKeep = true;
                _context.Routers.Add(router);
            }
            else
            {
                router.Key = key;
                router.ParentKey = parentKey;
                router.Name = name;
                router.Component = component;
                router.Redirect = redirect;
                router.Icon = icon;
                router.Sort = sort;
                router.IsKeep = true;
            }
            _context.SaveChanges();

            var role = _context.Roles.FirstOrDefault(o => o.Name == StaticRoleNames.Host.Admin && o.TenantId == null);
            if (role == null)
            {
                return;
            }
            var rolePermission = _context.RoleRouterPermissions.FirstOrDefault(o => o.RoleId == role.Id && o.Router.Key == key);
            if (rolePermission == null)
            {
                rolePermission = new RolePermission();
                rolePermission.RoleId = role.Id;
                rolePermission.Router = router;
                rolePermission.Actions =
                    "[{\"action\":\"add\",\"defaultCheck\":false,\"describe\":\"新增\"},{\"action\":\"query\",\"defaultCheck\":false,\"describe\":\"查询\"},{\"action\":\"get\",\"defaultCheck\":false,\"describe\":\"详情\"},{\"action\":\"update\",\"defaultCheck\":false,\"describe\":\"修改\"},{\"action\":\"delete\",\"defaultCheck\":false,\"describe\":\"删除\"}]";
                rolePermission.IsKeep = true;
                _context.RoleRouterPermissions.Add(rolePermission);
            }
            else
            {
                rolePermission.RoleId = role.Id;
                rolePermission.Router = router;
                rolePermission.Actions =
                    "[{\"action\":\"add\",\"defaultCheck\":false,\"describe\":\"新增\"},{\"action\":\"query\",\"defaultCheck\":false,\"describe\":\"查询\"},{\"action\":\"get\",\"defaultCheck\":false,\"describe\":\"详情\"},{\"action\":\"update\",\"defaultCheck\":false,\"describe\":\"修改\"},{\"action\":\"delete\",\"defaultCheck\":false,\"describe\":\"删除\"}]";
                rolePermission.IsKeep = true;
            }
            _context.SaveChanges();
        }

        private void ClearRouter()
        {
            var role = _context.Roles.FirstOrDefault(o => o.Name == StaticRoleNames.Host.Admin && o.TenantId == null);
            if (role != null)
            {
                var rolePermissions = _context.RoleRouterPermissions.Where(o => o.RoleId == role.Id);
                foreach (var rolePermission in rolePermissions)
                {
                    if (rolePermission.IsKeep)
                    {
                        rolePermission.IsKeep = false;
                    }
                    else
                    {
                        _context.RoleRouterPermissions.Remove(rolePermission);
                    }
                }
                _context.SaveChanges();
            }
            foreach (var router in _context.Routers)
            {
                if (router.IsKeep)
                {
                    router.IsKeep = false;
                }
                else
                {
                    _context.Routers.Remove(router);
                }
            }
            _context.SaveChanges();
        }
    }
}
