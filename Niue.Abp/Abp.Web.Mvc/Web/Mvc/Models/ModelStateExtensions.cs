using System.Collections.Generic;
using System.Web.Mvc;
using Niue.Abp.Abp.Dependency;
using Niue.Abp.Abp.Localization;
using Niue.Abp.Abp.Web.Common.Web;
using Niue.Abp.Abp.Web.Common.Web.Models;

namespace Niue.Abp.Abp.Web.Mvc.Web.Mvc.Models
{
    public static class ModelStateExtensions
    {
        public static AjaxResponse ToAjaxResponse(this ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
            {
                return new AjaxResponse();
            }

            var validationErrors = new List<ValidationErrorInfo>();

            foreach (var state in modelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    validationErrors.Add(new ValidationErrorInfo(error.ErrorMessage, state.Key));
                }
            }

            var errorInfo = new ErrorInfo(SingletonDependency<ILocalizationManager>.Instance.GetString(AbpWebConsts.LocalizaionSourceName, "ValidationError"))
            {
                ValidationErrors = validationErrors.ToArray()
            };

            return new AjaxResponse(errorInfo);
        }
    }
}
