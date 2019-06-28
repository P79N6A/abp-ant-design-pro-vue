using System.Linq;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Niue.Abp.Abp;
using Niue.Abp.Abp.Configuration.Startup;
using Niue.Abp.Abp.Dependency;
using Niue.Abp.Abp.Localization.Dictionaries;
using Niue.Abp.Abp.Localization.Dictionaries.Xml;
using Niue.Abp.Abp.Modules;
using Niue.Abp.Abp.MultiTenancy;
using Niue.Abp.Abp.Reflection;
using Niue.Abp.Zero.Abp.Zero.Application.Features;
using Niue.Abp.Zero.Abp.Zero.Authorization.Roles;
using Niue.Abp.Zero.Abp.Zero.Authorization.Users;
using Niue.Abp.Zero.Abp.Zero.Localization;
using Niue.Abp.Zero.Abp.Zero.MultiTenancy;
using Niue.Abp.Zero.Abp.Zero.Zero.Configuration;

namespace Niue.Abp.Zero.Abp.Zero.Zero
{
    /// <summary>
    /// ABP zero core module.
    /// </summary>
    [DependsOn(typeof(AbpKernelModule))]
    public class AbpZeroCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            IocManager.Register<IRoleManagementConfig, RoleManagementConfig>();
            IocManager.Register<IUserManagementConfig, UserManagementConfig>();
            IocManager.Register<ILanguageManagementConfig, LanguageManagementConfig>();
            IocManager.Register<IAbpZeroEntityTypes, AbpZeroEntityTypes>();
            IocManager.Register<IAbpZeroConfig, AbpZeroConfig>();

            Configuration.ReplaceService<ITenantStore, TenantStore>(DependencyLifeStyle.Transient);

            Configuration.Settings.Providers.Add<AbpZeroSettingProvider>();

            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    AbpZeroConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(), "Abp.Zero.Zero.Localization.Source"
                        )));

            IocManager.IocContainer.Kernel.ComponentRegistered += Kernel_ComponentRegistered;
        }

        public override void Initialize()
        {
            FillMissingEntityTypes();

            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            IocManager.Register<IMultiTenantLocalizationDictionary, MultiTenantLocalizationDictionary>(DependencyLifeStyle.Transient); //could not register conventionally

            RegisterTenantCache();
        }

        private void Kernel_ComponentRegistered(string key, Castle.MicroKernel.IHandler handler)
        {
            if (typeof(IAbpZeroFeatureValueStore).IsAssignableFrom(handler.ComponentModel.Implementation) && !IocManager.IsRegistered<IAbpZeroFeatureValueStore>())
            {
                IocManager.IocContainer.Register(
                    Component.For<IAbpZeroFeatureValueStore>().ImplementedBy(handler.ComponentModel.Implementation).Named("AbpZeroFeatureValueStore").LifestyleTransient()
                    );
            }
        }

        private void FillMissingEntityTypes()
        {
            using (var entityTypes = IocManager.ResolveAsDisposable<IAbpZeroEntityTypes>())
            {
                if (entityTypes.Object.User != null &&
                    entityTypes.Object.Role != null &&
                    entityTypes.Object.Tenant != null)
                {
                    return;
                }

                using (var typeFinder = IocManager.ResolveAsDisposable<ITypeFinder>())
                {
                    var types = typeFinder.Object.FindAll();
                    entityTypes.Object.Tenant = types.FirstOrDefault(t => typeof(AbpTenantBase).IsAssignableFrom(t) && !t.IsAbstract);
                    entityTypes.Object.Role = types.FirstOrDefault(t => typeof(AbpRoleBase).IsAssignableFrom(t) && !t.IsAbstract);
                    entityTypes.Object.User = types.FirstOrDefault(t => typeof(AbpUserBase).IsAssignableFrom(t) && !t.IsAbstract);
                }
            }
        }

        private void RegisterTenantCache()
        {
            if (IocManager.IsRegistered<ITenantCache>())
            {
                return;
            }

            using (var entityTypes = IocManager.ResolveAsDisposable<IAbpZeroEntityTypes>())
            {
                var implType = typeof (TenantCache<,>)
                    .MakeGenericType(entityTypes.Object.Tenant, entityTypes.Object.User);

                IocManager.Register(typeof (ITenantCache), implType, DependencyLifeStyle.Transient);
            }
        }
    }
}
