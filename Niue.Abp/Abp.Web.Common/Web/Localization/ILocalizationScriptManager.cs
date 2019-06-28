﻿using System.Globalization;

namespace Niue.Abp.Abp.Web.Common.Web.Localization
{
    /// <summary>
    /// Define interface to get localization javascript.
    /// </summary>
    public interface ILocalizationScriptManager
    {
        /// <summary>
        /// Gets Javascript that contains all localization information in current culture.
        /// </summary>
        string GetScript();

        /// <summary>
        /// Gets Javascript that contains all localization information in given culture.
        /// </summary>
        /// <param name="cultureInfo">Culture to get script</param>
        string GetScript(CultureInfo cultureInfo);
    }
}