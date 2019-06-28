using System.Web.Mvc;
using Niue.Abp.Abp.Web.Mvc.Web.Mvc.Authorization;

namespace Niue.Web.Controllers
{
    [AbpMvcAuthorize]
    public class CmsController : NiueControllerBase
    {
        public ActionResult Index()
        {
            return View(); //Layout of the angular application.
        }
	}
}