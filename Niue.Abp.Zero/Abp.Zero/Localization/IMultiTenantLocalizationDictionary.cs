using System.Collections.Generic;
using Niue.Abp.Abp.Localization;
using Niue.Abp.Abp.Localization.Dictionaries;

namespace Niue.Abp.Zero.Abp.Zero.Localization
{
    /// <summary>
    /// Extends <see cref="ILocalizationDictionary"/> to add tenant and database based localization.
    /// </summary>
    public interface IMultiTenantLocalizationDictionary : ILocalizationDictionary
    {
        /// <summary>
        /// Gets a <see cref="LocalizedString"/>.
        /// </summary>
        /// <param name="tenantId">TenantId or null for host.</param>
        /// <param name="name">Localization key name.</param>
        LocalizedString GetOrNull(int? tenantId, string name);

        /// <summary>
        /// Gets all <see cref="LocalizedString"/>s.
        /// </summary>
        /// <param name="tenantId">TenantId or null for host.</param>
        IReadOnlyList<LocalizedString> GetAllStrings(int? tenantId);
    }
}