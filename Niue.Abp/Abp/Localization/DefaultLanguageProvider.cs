using System.Collections.Generic;
using System.Collections.Immutable;
using Niue.Abp.Abp.Configuration.Startup;
using Niue.Abp.Abp.Dependency;

namespace Niue.Abp.Abp.Localization
{
    public class DefaultLanguageProvider : ILanguageProvider, ITransientDependency
    {
        private readonly ILocalizationConfiguration _configuration;

        public DefaultLanguageProvider(ILocalizationConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IReadOnlyList<LanguageInfo> GetLanguages()
        {
            return _configuration.Languages.ToImmutableList();
        }
    }
}