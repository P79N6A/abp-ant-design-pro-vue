﻿using System.Collections.Generic;
using Niue.Abp.Abp.Configuration;
using Niue.Abp.Abp.Localization;

namespace Niue.Abp.Abp.Timing
{
    public class TimingSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                new SettingDefinition(TimingSettingNames.TimeZone, "UTC", L("TimeZone"), scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true)
            };
        }

        private static LocalizableString L(string name)
        {
            return new LocalizableString(name, AbpConsts.LocalizationSourceName);
        }
    }
}
