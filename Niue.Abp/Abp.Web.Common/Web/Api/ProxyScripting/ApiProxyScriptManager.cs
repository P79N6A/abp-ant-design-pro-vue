﻿using System.Collections.Concurrent;
using Niue.Abp.Abp.Collections.Extensions;
using Niue.Abp.Abp.Dependency;
using Niue.Abp.Abp.Extensions;
using Niue.Abp.Abp.Json;
using Niue.Abp.Abp.Web.Common.Web.Api.Modeling;
using Niue.Abp.Abp.Web.Common.Web.Api.ProxyScripting.Configuration;
using Niue.Abp.Abp.Web.Common.Web.Api.ProxyScripting.Generators;

namespace Niue.Abp.Abp.Web.Common.Web.Api.ProxyScripting
{
    public class ApiProxyScriptManager : IApiProxyScriptManager, ISingletonDependency
    {
        private readonly IApiDescriptionModelProvider _modelProvider;
        private readonly IApiProxyScriptingConfiguration _configuration;
        private readonly IIocResolver _iocResolver;

        private readonly ConcurrentDictionary<string, string> _cache;

        public ApiProxyScriptManager(
            IApiDescriptionModelProvider modelProvider, 
            IApiProxyScriptingConfiguration configuration,
            IIocResolver iocResolver)
        {
            _modelProvider = modelProvider;
            _configuration = configuration;
            _iocResolver = iocResolver;

            _cache = new ConcurrentDictionary<string, string>();
        }

        public string GetScript(ApiProxyGenerationOptions options)
        {
            if (options.UseCache)
            {
                return _cache.GetOrAdd(CreateCacheKey(options), key => CreateScript(options));
            }

            return _cache[CreateCacheKey(options)] = CreateScript(options);
        }

        private string CreateScript(ApiProxyGenerationOptions options)
        {
            var model = _modelProvider.CreateModel();

            if (options.IsPartialRequest())
            {
                model = model.CreateSubModel(options.Modules, options.Controllers, options.Actions);
            }

            var generatorType = _configuration.Generators.GetOrDefault(options.GeneratorType);
            if (generatorType == null)
            {
                throw new AbpException($"Could not find a proxy script generator with given name: {options.GeneratorType}");
            }

            using (var generator = _iocResolver.ResolveAsDisposable<IProxyScriptGenerator>(generatorType))
            {
                return generator.Object.CreateScript(model);
            }
        }

        private static string CreateCacheKey(ApiProxyGenerationOptions options)
        {
            return options.ToJsonString().ToMd5();
        }
    }
}
