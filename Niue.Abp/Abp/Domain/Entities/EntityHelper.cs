using System;
using Niue.Abp.Abp.Reflection;

namespace Niue.Abp.Abp.Domain.Entities
{
    /// <summary>
    /// Some helper methods for entities.
    /// </summary>
    public static class EntityHelper
    {
        public static bool IsEntity(Type type)
        {
            return ReflectionHelper.IsAssignableToGenericType(type, typeof (IEntity<>));
        }

        public static Type GetPrimaryKeyType<TEntity>()
        {
            return GetPrimaryKeyType(typeof (TEntity));
        }

        /// <summary>
        /// Gets primary key type of given entity type
        /// </summary>
        public static Type GetPrimaryKeyType(Type entityType)
        {
            foreach (var interfaceType in entityType.GetInterfaces())
            {
                if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof (IEntity<>))
                {
                    return interfaceType.GenericTypeArguments[0];
                }
            }

            throw new AbpException("Can not find primary key type of given entity type: " + entityType + ". Be sure that this entity type implements IEntity<TPrimaryKey> interface");
        }
    }
}