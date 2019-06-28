using System.Reflection;
using Niue.Abp.Abp.Localization.Dictionaries;
using Niue.Abp.Abp.Localization.Dictionaries.Xml;
using Niue.Abp.Abp.Modules;
using Niue.Abp.Zero.Abp.Zero.Zero;
using Niue.Abp.Zero.Abp.Zero.Zero.Configuration;
using Niue.Core.Authorization;
using Niue.Core.Authorization.Roles;
using Niue.Core.MultiTenancy;
using Niue.Core.Users;

namespace Niue.Core
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class NiueCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            //Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            //Remove the following line to disable multi-tenancy.
            Configuration.MultiTenancy.IsEnabled = true;

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    NiueConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "Niue.Localization.Source"
                        )
                    )
                );

            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Authorization.Providers.Add<NiueAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
