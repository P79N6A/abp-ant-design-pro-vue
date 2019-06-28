using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Niue.Abp.Abp.Dependency;
using Niue.Abp.Abp.Domain.Uow;
using Niue.Abp.Abp.Web.Api.WebApi.Configuration;
using Niue.Abp.Abp.Web.Api.WebApi.Validation;

namespace Niue.Abp.Abp.Web.Api.WebApi.Uow
{
    public class AbpApiUowFilter : IActionFilter, ITransientDependency
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IAbpWebApiConfiguration _configuration;

        public bool AllowMultiple => false;

        public AbpApiUowFilter(
            IUnitOfWorkManager unitOfWorkManager,
            IAbpWebApiConfiguration configuration
            )
        {
            _unitOfWorkManager = unitOfWorkManager;
            _configuration = configuration;
        }

        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            var methodInfo = actionContext.ActionDescriptor.GetMethodInfoOrNull();
            if (methodInfo == null)
            {
                return await continuation();
            }

            if (actionContext.ActionDescriptor.IsDynamicAbpAction())
            {
                return await continuation();
            }

            var unitOfWorkAttr = UnitOfWorkAttribute.GetUnitOfWorkAttributeOrNull(methodInfo) ??
                                 _configuration.DefaultUnitOfWorkAttribute;

            if (unitOfWorkAttr.IsDisabled)
            {
                return await continuation();
            }

            using (var uow = _unitOfWorkManager.Begin(unitOfWorkAttr.CreateOptions()))
            {
                var result = await continuation();
                await uow.CompleteAsync();
                return result;
            }
        }
    }
}