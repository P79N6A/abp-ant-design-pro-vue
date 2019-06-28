﻿using System.Collections.Generic;
using Niue.Abp.Abp.Configuration;
using Niue.Abp.Abp.Localization;

namespace Niue.Abp.Zero.Abp.Zero.Zero.Configuration
{
    public class AbpZeroSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new List<SettingDefinition>
                   {
                       new SettingDefinition(
                           AbpZeroSettingNames.UserManagement.IsEmailConfirmationRequiredForLogin,
                           "false",
                           new FixedLocalizableString("Is email confirmation required for login."),
                           scopes: SettingScopes.Application | SettingScopes.Tenant,
                           isVisibleToClients: true
                           ),

                       new SettingDefinition(
                           AbpZeroSettingNames.OrganizationUnits.MaxUserMembershipCount,
                           int.MaxValue.ToString(),
                           new FixedLocalizableString("Maximum allowed organization unit membership count for a user."),
                           scopes: SettingScopes.Application | SettingScopes.Tenant,
                           isVisibleToClients: true
                           ),

                       new SettingDefinition(
                           AbpZeroSettingNames.UserManagement.TwoFactorLogin.IsEnabled,
                           "true",
                           new FixedLocalizableString("Is two factor login enabled."),
                           scopes: SettingScopes.Application | SettingScopes.Tenant,
                           isVisibleToClients: true
                           ),

                       new SettingDefinition(
                           AbpZeroSettingNames.UserManagement.TwoFactorLogin.IsRememberBrowserEnabled,
                           "true",
                           new FixedLocalizableString("Is browser remembering enabled for two factor login."),
                           scopes: SettingScopes.Application | SettingScopes.Tenant,
                           isVisibleToClients: true
                           ),

                       new SettingDefinition(
                           AbpZeroSettingNames.UserManagement.TwoFactorLogin.IsEmailProviderEnabled,
                           "true",
                           new FixedLocalizableString("Is email provider enabled for two factor login."),
                           scopes: SettingScopes.Application | SettingScopes.Tenant,
                           isVisibleToClients: true
                           ),

                       new SettingDefinition(
                           AbpZeroSettingNames.UserManagement.TwoFactorLogin.IsSmsProviderEnabled,
                           "true",
                           new FixedLocalizableString("Is sms provider enabled for two factor login."),
                           scopes: SettingScopes.Application | SettingScopes.Tenant,
                           isVisibleToClients: true
                           ),

                       new SettingDefinition(
                           AbpZeroSettingNames.UserManagement.UserLockOut.IsEnabled,
                           "true",
                           new FixedLocalizableString("Is user lockout enabled."),
                           scopes: SettingScopes.Application | SettingScopes.Tenant,
                           isVisibleToClients: true
                           ),

                       new SettingDefinition(
                           AbpZeroSettingNames.UserManagement.UserLockOut.MaxFailedAccessAttemptsBeforeLockout,
                           "5",
                           new FixedLocalizableString("Maxumum Failed access attempt count before user lockout."),
                           scopes: SettingScopes.Application | SettingScopes.Tenant,
                           isVisibleToClients: true
                           ),

                       new SettingDefinition(
                           AbpZeroSettingNames.UserManagement.UserLockOut.DefaultAccountLockoutSeconds,
                           "300", //5 minutes
                           new FixedLocalizableString("User lockout in seconds."),
                           scopes: SettingScopes.Application | SettingScopes.Tenant,
                           isVisibleToClients: true
                           ),
                   };
        }
    }
}
