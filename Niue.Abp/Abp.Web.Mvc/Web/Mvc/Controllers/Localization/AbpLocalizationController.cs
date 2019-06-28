using System.Web;
using System.Web.Mvc;
using Niue.Abp.Abp.Auditing;
using Niue.Abp.Abp.Configuration;
using Niue.Abp.Abp.Localization;
using Niue.Abp.Abp.Runtime.Session;
using Niue.Abp.Abp.Timing;
using Niue.Abp.Abp.Web.Common.Web.Models;
using Niue.Abp.Abp.Web.Web;
using Niue.Abp.Abp.Web.Web.Configuration;

namespace Niue.Abp.Abp.Web.Mvc.Web.Mvc.Controllers.Localization
{
    public class AbpLocalizationController : AbpController
    {
        private readonly IAbpWebLocalizationConfiguration _webLocalizationConfiguration;

        public AbpLocalizationController(IAbpWebLocalizationConfiguration webLocalizationConfiguration)
        {
            _webLocalizationConfiguration = webLocalizationConfiguration;
        }

        [DisableAuditing]
        public virtual ActionResult ChangeCulture(string cultureName, string returnUrl = "")
        {
            if (!GlobalizationHelper.IsValidCultureCode(cultureName))
            {
                throw new AbpException("Unknown language: " + cultureName + ". It must be a valid culture!");
            }

            Response.Cookies.Add(
                new HttpCookie(_webLocalizationConfiguration.CookieName, cultureName)
                {
                    Expires = Clock.Now.AddYears(2)
                }
            );

            if (AbpSession.UserId.HasValue)
            {
                SettingManager.ChangeSettingForUser(
                    AbpSession.ToUserIdentifier(),
                    LocalizationSettingNames.DefaultLanguage,
                    cultureName
                );
            }

            if (Request.IsAjaxRequest())
            {
                return Json(new AjaxResponse(), JsonRequestBehavior.AllowGet);
            }

            if (!string.IsNullOrWhiteSpace(returnUrl) && Request.Url != null && AbpUrlHelper.IsLocalUrl(Request.Url, returnUrl))
            {
                return Redirect(returnUrl);
            }

            return Redirect(Request.ApplicationPath);
        }
    }
}
