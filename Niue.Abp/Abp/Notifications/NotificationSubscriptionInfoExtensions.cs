﻿using System;
using Newtonsoft.Json;
using Niue.Abp.Abp.Domain.Entities;
using Niue.Abp.Abp.Extensions;

namespace Niue.Abp.Abp.Notifications
{
    /// <summary>
    /// Extension methods for <see cref="NotificationSubscriptionInfo"/>.
    /// </summary>
    public static class NotificationSubscriptionInfoExtensions
    {
        /// <summary>
        /// Converts <see cref="UserNotificationInfo"/> to <see cref="UserNotification"/>.
        /// </summary>
        public static NotificationSubscription ToNotificationSubscription(this NotificationSubscriptionInfo subscriptionInfo)
        {
            var entityType = subscriptionInfo.EntityTypeAssemblyQualifiedName.IsNullOrEmpty()
                ? null
                : Type.GetType(subscriptionInfo.EntityTypeAssemblyQualifiedName);

            return new NotificationSubscription
            {
                TenantId = subscriptionInfo.TenantId,
                UserId = subscriptionInfo.UserId,
                NotificationName = subscriptionInfo.NotificationName,
                EntityType = entityType,
                EntityTypeName = subscriptionInfo.EntityTypeName,
                EntityId = subscriptionInfo.EntityId.IsNullOrEmpty() ? null : JsonConvert.DeserializeObject(subscriptionInfo.EntityId, EntityHelper.GetPrimaryKeyType(entityType)),
                CreationTime = subscriptionInfo.CreationTime
            };
        }
    }
}