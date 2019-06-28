using System;
using Castle.Core.Logging;
using Niue.Abp.Abp.Dependency;
using Niue.Abp.Abp.Domain.Entities;
using Niue.Abp.Abp.EntityFramework.Common;
using Niue.Abp.Abp.Reflection.Extensions;

namespace Niue.Abp.Abp.EntityFramework.EntityFramework.Repositories
{
    public class EntityFrameworkGenericRepositoryRegistrar : IEntityFrameworkGenericRepositoryRegistrar, ITransientDependency
    {
        public ILogger Logger { get; set; }

        public EntityFrameworkGenericRepositoryRegistrar()
        {
            Logger = NullLogger.Instance;
        }

        public void RegisterForDbContext(Type dbContextType, IIocManager iocManager)
        {
            var autoRepositoryAttr = dbContextType.GetSingleAttributeOrNull<AutoRepositoryTypesAttribute>() ??
                                     EfAutoRepositoryTypes.Default;

            foreach (var entityTypeInfo in DbContextHelper.GetEntityTypeInfos(dbContextType))
            {
                var primaryKeyType = EntityHelper.GetPrimaryKeyType(entityTypeInfo.EntityType);
                if (primaryKeyType == typeof(int))
                {
                    var genericRepositoryType = autoRepositoryAttr.RepositoryInterface.MakeGenericType(entityTypeInfo.EntityType);
                    if (!iocManager.IsRegistered(genericRepositoryType))
                    {
                        var implType = autoRepositoryAttr.RepositoryImplementation.GetGenericArguments().Length == 1
                                ? autoRepositoryAttr.RepositoryImplementation.MakeGenericType(entityTypeInfo.EntityType)
                                : autoRepositoryAttr.RepositoryImplementation.MakeGenericType(entityTypeInfo.DeclaringType, entityTypeInfo.EntityType);

                        iocManager.Register(
                            genericRepositoryType,
                            implType,
                            DependencyLifeStyle.Transient
                            );
                    }
                }

                var genericRepositoryTypeWithPrimaryKey = autoRepositoryAttr.RepositoryInterfaceWithPrimaryKey.MakeGenericType(entityTypeInfo.EntityType, primaryKeyType);
                if (!iocManager.IsRegistered(genericRepositoryTypeWithPrimaryKey))
                {
                    var implType = autoRepositoryAttr.RepositoryImplementationWithPrimaryKey.GetGenericArguments().Length == 2
                                ? autoRepositoryAttr.RepositoryImplementationWithPrimaryKey.MakeGenericType(entityTypeInfo.EntityType, primaryKeyType)
                                : autoRepositoryAttr.RepositoryImplementationWithPrimaryKey.MakeGenericType(entityTypeInfo.DeclaringType, entityTypeInfo.EntityType, primaryKeyType);

                    iocManager.Register(
                        genericRepositoryTypeWithPrimaryKey,
                        implType,
                        DependencyLifeStyle.Transient
                        );
                }
            }
        }
    }
}