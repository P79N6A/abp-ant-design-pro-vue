using Niue.Abp.Abp.Localization.Sources;

namespace Niue.Abp.Abp.Localization.Dictionaries
{
    /// <summary>
    /// Interface for a dictionary based localization source.
    /// </summary>
    public interface IDictionaryBasedLocalizationSource : ILocalizationSource
    {
        /// <summary>
        /// Gets the dictionary provider.
        /// </summary>
        ILocalizationDictionaryProvider DictionaryProvider { get; }

        /// <summary>
        /// Extends the source with given dictionary.
        /// </summary>
        /// <param name="dictionary">Dictionary to extend the source</param>
        void Extend(ILocalizationDictionary dictionary);
    }
}