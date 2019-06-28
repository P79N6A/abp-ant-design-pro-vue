using System;
using System.Web.Mvc;
using Niue.Abp.Abp.Auditing;
using Niue.Abp.Abp.Domain.Uow;
using Niue.Abp.Abp.Extensions;
using Niue.Abp.Abp.Runtime.Validation;

namespace Niue.Abp.Abp.Web.Mvc.Web.Mvc.Controllers
{
    public class AbpAppViewController : AbpController
    {
        [DisableAuditing]
        [DisableValidation]
        [UnitOfWork(IsDisabled = true)]
        public ActionResult Load(string viewUrl)
        {
            if (viewUrl.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(viewUrl));
            }

            return View(viewUrl.EnsureStartsWith('~'));
        }
    }
}
