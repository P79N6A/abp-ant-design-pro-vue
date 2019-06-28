using System.Collections.Generic;
using System.Globalization;
using Niue.Abp.Abp.Localization;
using Niue.Abp.Abp.Localization.Dictionaries;

namespace Niue.Abp.Zero.Abp.Zero.Localization
{
    internal class EmptyDictionary : ILocalizationDictionary
    {
        public CultureInfo CultureInfo { get; private set; }

        public EmptyDictionary(CultureInfo cultureInfo)
        {
            CultureInfo = cultureInfo;
        }

        public LocalizedString GetOrNull(string name)
        {
            return null;
        }

        public IReadOnlyList<LocalizedString> GetAllStrings()
        {
            return new LocalizedString[0];
        }

        public string this[string name]
        {
            get { return null; }
            set { }
        }
    }
}