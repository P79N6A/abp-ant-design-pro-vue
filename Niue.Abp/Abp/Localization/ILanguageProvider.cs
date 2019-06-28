using System.Collections.Generic;

namespace Niue.Abp.Abp.Localization
{
    public interface ILanguageProvider
    {
        IReadOnlyList<LanguageInfo> GetLanguages();
    }
}