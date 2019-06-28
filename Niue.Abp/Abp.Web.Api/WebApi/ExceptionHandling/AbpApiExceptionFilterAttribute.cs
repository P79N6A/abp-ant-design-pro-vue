using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using Castle.Core.Logging;
using Niue.Abp.Abp.Dependency;
using Niue.Abp.Abp.Domain.Entities;
using Niue.Abp.Abp.Events.Bus;
using Niue.Abp.Abp.Events.Bus.Exceptions;
using Niue.Abp.Abp.Extensions;
using Niue.Abp.Abp.Logging;
using Niue.Abp.Abp.Runtime.Session;
using Niue.Abp.Abp.Runtime.Validation;
using Niue.Abp.Abp.Web.Api.WebApi.Configuration;
using Niue.Abp.Abp.Web.Api.WebApi.Controllers;
using Niue.Abp.Abp.Web.Common.Web.Models;

namespace Niue.Abp.Abp.Web.Api.WebApi.ExceptionHandling
{
    /// <summary>
    /// Used to handle exceptions on web api controllers.
    /// </summary>
    public class AbpApiExceptionFilterAttribute : ExceptionFilterAttribute, ITransientDependency
    {
        /// <summary>
        /// Reference to the <see cref="ILogger"/>.
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// Reference to the <see cref="IEventBus"/>.
        /// </summary>
        public IEventBus EventBus { get; set; }

        public IAbpSession AbpSession { get; set; }

        protected IAbpWebApiConfiguration Configuration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbpApiExceptionFilterAttribute"/> class.
        /// </summary>
        public AbpApiExceptionFilterAttribute(IAbpWebApiConfiguration configuration)
        {
            Configuration = configuration;
            Logger = NullLogger.Instance;
            EventBus = NullEventBus.Instance;
            AbpSession = NullAbpSession.Instance;
        }

        /// <summary>
        /// Raises the exception event.
        /// </summary>
        /// <param name="context">The context for the action.</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            var wrapResultAttribute = HttpActionDescriptorHelper
                .GetWrapResultAttributeOrNull(context.ActionContext.ActionDescriptor) ??
                Configuration.DefaultWrapResultAttribute;

            if (wrapResultAttribute.LogError)
            {
                LogHelper.LogException(Logger, context.Exception);
            }

            if (!wrapResultAttribute.WrapOnError)
            {
                return;
            }

            if (IsIgnoredUrl(context.Request.RequestUri))
            {
                return;
            }

            if (context.Exception is HttpException)
            {
                var httpException = context.Exception as HttpException;
                var httpStatusCode = (HttpStatusCode) httpException.GetHttpCode();

                context.Response = context.Request.CreateResponse(
                    httpStatusCode,
                    new AjaxResponse(
                        new ErrorInfo(httpException.Message),
                        httpStatusCode == HttpStatusCode.Unauthorized || httpStatusCode == HttpStatusCode.Forbidden
                    )
                );
            }
            else
            {
                context.Response = context.Request.CreateResponse(
                    GetStatusCode(context),
                    new AjaxResponse(
                        SingletonDependency<ErrorInfoBuilder>.Instance.BuildForException(context.Exception),
                        context.Exception is Niue.Abp.Abp.Authorization.AbpAuthorizationException)
                );
            }

            EventBus.Trigger(this, new AbpHandledExceptionData(context.Exception));
        }

        protected virtual HttpStatusCode GetStatusCode(HttpActionExecutedContext context)
        {
            if (context.Exception is Niue.Abp.Abp.Authorization.AbpAuthorizationException)
            {
                return AbpSession.UserId.HasValue
                    ? HttpStatusCode.Forbidden
                    : HttpStatusCode.Unauthorized;
            }

            if (context.Exception is AbpValidationException)
            {
                return HttpStatusCode.BadRequest;
            }

            if (context.Exception is EntityNotFoundException)
            {
                return HttpStatusCode.NotFound;
            }

            return HttpStatusCode.InternalServerError;
        }

        protected virtual bool IsIgnoredUrl(Uri uri)
        {
            if (uri == null || uri.AbsolutePath.IsNullOrEmpty())
            {
                return false;
            }

            return Configuration.ResultWrappingIgnoreUrls.Any(url => uri.AbsolutePath.StartsWith(url));
        }
    }
}