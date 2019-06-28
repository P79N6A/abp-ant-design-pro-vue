using Newtonsoft.Json;
using Niue.Abp.Abp.Localization;

namespace Niue.Abp.Abp.UI.Inputs
{
    public interface ILocalizableComboboxItem
    {
        string Value { get; set; }

        [JsonConverter(typeof(LocalizableStringToStringJsonConverter))]
        ILocalizableString DisplayText { get; set; }
    }
}