using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Castle.Core.Logging;
using Niue.Abp.Abp.Dependency;
using Niue.Abp.Abp.Web.Api.Web.Security.AntiForgery;
using Niue.Abp.Abp.Web.Api.WebApi.Configuration;
using Niue.Abp.Abp.Web.Api.WebApi.Controllers.Dynamic.Selectors;
using Niue.Abp.Abp.Web.Api.WebApi.Validation;
using Niue.Abp.Abp.Web.Common.Web.Security.AntiForgery;
using Niue.Abp.Abp.Web.Web.Security.AntiForgery;

namespace Niue.Abp.Abp.Web.Api.WebApi.Security.AntiForgery
{
    public class AbpAntiForgeryApiFilter : IAuthorizationFilter, ITransientDependency
    {
        public ILogger Logger { get; set; }

        public bool AllowMultiple => false;

        private readonly IAbpAntiForgeryManager _abpAntiForgeryManager;
        private readonly IAbpWebApiConfiguration _webApiConfiguration;
        private readonly IAbpAntiForgeryWebConfiguration _antiForgeryWebConfiguration;

        public AbpAntiForgeryApiFilter(
            IAbpAntiForgeryManager abpAntiForgeryManager, 
            IAbpWebApiConfiguration webApiConfiguration,
            IAbpAntiForgeryWebConfiguration antiForgeryWebConfiguration)
        {
            _abpAntiForgeryManager = abpAntiForgeryManager;
            _webApiConfiguration = webApiConfiguration;
            _antiForgeryWebConfiguration = antiForgeryWebConfiguration;
            Logger = NullLogger.Instance;
        }

        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(
            HttpActionContext actionContext,
            CancellationToken cancellationToken,
            Func<Task<HttpResponseMessage>> continuation)
        {
            var methodInfo = actionContext.ActionDescriptor.GetMethodInfoOrNull();
            if (methodInfo == null)
            {
                return await continuation();
            }

            if (!_abpAntiForgeryManager.ShouldValidate(_antiForgeryWebConfiguration, methodInfo, actionContext.Request.Method.ToHttpVerb(), _webApiConfiguration.IsAutomaticAntiForgeryValidationEnabled))
            {
                return await continuation();
            }

            if (!_abpAntiForgeryManager.IsValid(actionContext.Request.Headers))
            {
                return CreateErrorResponse(actionContext, "Empty or invalid anti forgery header token.");
            }

            return await continuation();
        }

        protected virtual HttpResponseMessage CreateErrorResponse(HttpActionContext actionContext, string reason)
        {
            Logger.Warn(reason);
            Logger.Warn("Requested URI: " + actionContext.Request.RequestUri);
            return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = reason };
        }
    }
}