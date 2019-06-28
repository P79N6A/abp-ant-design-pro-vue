﻿using System;
using Newtonsoft.Json;
using Niue.Abp.Abp.Domain.Entities;
using Niue.Abp.Abp.Extensions;

namespace Niue.Abp.Abp.Notifications
{
    /// <summary>
    /// Extension methods for <see cref="NotificationInfo"/>.
    /// </summary>
    public static class TenantNotificationInfoExtensions
    {
        /// <summary>
        /// Converts <see cref="NotificationInfo"/> to <see cref="TenantNotification"/>.
        /// </summary>
        public static TenantNotification ToTenantNotification(this TenantNotificationInfo tenantNotificationInfo)
        {
            var entityType = tenantNotificationInfo.EntityTypeAssemblyQualifiedName.IsNullOrEmpty()
                ? null
                : Type.GetType(tenantNotificationInfo.EntityTypeAssemblyQualifiedName);

            return new TenantNotification
            {
                Id = tenantNotificationInfo.Id,
                TenantId = tenantNotificationInfo.TenantId,
                NotificationName = tenantNotificationInfo.NotificationName,
                Data = tenantNotificationInfo.Data.IsNullOrEmpty() ? null : JsonConvert.DeserializeObject(tenantNotificationInfo.Data, Type.GetType(tenantNotificationInfo.DataTypeName)) as NotificationData,
                EntityTypeName = tenantNotificationInfo.EntityTypeName,
                EntityType = entityType,
                EntityId = tenantNotificationInfo.EntityId.IsNullOrEmpty() ? null : JsonConvert.DeserializeObject(tenantNotificationInfo.EntityId, EntityHelper.GetPrimaryKeyType(entityType)),
                Severity = tenantNotificationInfo.Severity,
                CreationTime = tenantNotificationInfo.CreationTime
            };
        }
    }
}
