using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Niue.Abp.Abp.Collections.Extensions;
using Niue.Abp.Abp.Extensions;
using Niue.Abp.Abp.Runtime.Caching;
using Niue.Abp.Abp.UI;
using Niue.Abp.Abp.Web.Api.WebApi.Controllers;
using Niue.Abp.Abp.Web.Common.Web.Models;
using Niue.Abp.Abp.Web.Models;

namespace Niue.Abp.Abp.Web.Api.WebApi.Runtime.Caching
{
    [DontWrapResult]
    public class AbpCacheController : AbpApiController
    {
        private readonly ICacheManager _cacheManager;

        public AbpCacheController(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        [HttpPost]
        public async Task<AjaxResponse> Clear(ClearCacheModel model)
        {
            if (model.Password.IsNullOrEmpty())
            {
                throw new UserFriendlyException("Password can not be null or empty!");
            }

            if (model.Caches.IsNullOrEmpty())
            {
                throw new UserFriendlyException("Caches can not be null or empty!");
            }

            await CheckPassword(model.Password);

            var caches = _cacheManager.GetAllCaches().Where(c => model.Caches.Contains(c.Name));
            foreach (var cache in caches)
            {
                await cache.ClearAsync();
            }

            return new AjaxResponse();
        }

        [HttpPost]
        [Route("api/AbpCache/ClearAll")]
        public async Task<AjaxResponse> ClearAll(ClearAllCacheModel model)
        {
            if (model.Password.IsNullOrEmpty())
            {
                throw new UserFriendlyException("Password can not be null or empty!");
            }

            await CheckPassword(model.Password);

            var caches = _cacheManager.GetAllCaches();
            foreach (var cache in caches)
            {
                await cache.ClearAsync();
            }

            return new AjaxResponse();
        }

        private async Task CheckPassword(string password)
        {
            var actualPassword = await SettingManager.GetSettingValueAsync(ClearCacheSettingNames.Password);
            if (actualPassword != password)
            {
                throw new UserFriendlyException("Password is not correct!");
            }
        }
    }
}
