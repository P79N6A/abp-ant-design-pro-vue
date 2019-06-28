using Microsoft.AspNet.Identity;
using Niue.Abp.Abp.UI;
using Niue.Abp.Abp.Web.Mvc.Web.Mvc.Controllers;
using Niue.Abp.Zero.Abp.Zero.IdentityFramework;
using Niue.Core;

namespace Niue.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class NiueControllerBase : AbpController
    {
        protected NiueControllerBase()
        {
            LocalizationSourceName = NiueConsts.LocalizationSourceName;
        }

        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException(L("FormIsNotValidMessage"));
            }
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}