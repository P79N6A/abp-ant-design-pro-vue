﻿using System.Web.Mvc;
using Niue.Abp.Abp.Dependency;
using Niue.Abp.Abp.Web.Mvc.Web.Mvc.Configuration;
using Niue.Abp.Abp.Web.Mvc.Web.Mvc.Extensions;

namespace Niue.Abp.Abp.Web.Mvc.Web.Mvc.Validation
{
    public class AbpMvcValidationFilter : IActionFilter, ITransientDependency
    {
        private readonly IIocResolver _iocResolver;
        private readonly IAbpMvcConfiguration _configuration;

        public AbpMvcValidationFilter(IIocResolver iocResolver, IAbpMvcConfiguration configuration)
        {
            _iocResolver = iocResolver;
            _configuration = configuration;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!_configuration.IsValidationEnabledForControllers)
            {
                return;
            }

            var methodInfo = filterContext.ActionDescriptor.GetMethodInfoOrNull();
            if (methodInfo == null)
            {
                return;
            }

            using (var validator = _iocResolver.ResolveAsDisposable<MvcActionInvocationValidator>())
            {
                validator.Object.Initialize(filterContext, methodInfo);
                validator.Object.Validate();
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }
    }
}
