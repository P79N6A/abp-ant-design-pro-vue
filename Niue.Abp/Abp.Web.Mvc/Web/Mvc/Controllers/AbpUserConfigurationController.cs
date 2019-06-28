using System.Threading.Tasks;
using System.Web.Mvc;
using Niue.Abp.Abp.Web.Common.Web.Configuration;

namespace Niue.Abp.Abp.Web.Mvc.Web.Mvc.Controllers
{
    public class AbpUserConfigurationController : AbpController
    {
        private readonly AbpUserConfigurationBuilder _abpUserConfigurationBuilder;

        public AbpUserConfigurationController(AbpUserConfigurationBuilder abpUserConfigurationBuilder)
        {
            _abpUserConfigurationBuilder = abpUserConfigurationBuilder;
        }

        public async Task<JsonResult> GetAll()
        {
            var userConfig = await _abpUserConfigurationBuilder.GetAll();
            return Json(userConfig, JsonRequestBehavior.AllowGet);
        }
    }
}