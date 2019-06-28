﻿using System.Reflection;

namespace Niue.Abp.Abp.Web.Api.WebApi.Controllers.Dynamic.Builders
{
    public interface IDynamicApiControllerBuilder
    {
        IApiControllerBuilder<T> For<T>(string serviceName);

        IBatchApiControllerBuilder<T> ForAll<T>(Assembly assembly, string servicePrefix);
    }
}