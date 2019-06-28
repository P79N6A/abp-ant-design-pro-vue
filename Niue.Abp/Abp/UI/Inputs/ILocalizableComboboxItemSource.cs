using System.Collections.Generic;

namespace Niue.Abp.Abp.UI.Inputs
{
    public interface ILocalizableComboboxItemSource
    {
        ICollection<ILocalizableComboboxItem> Items { get; }
    }
}