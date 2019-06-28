﻿using System;
using Niue.Abp.Abp.Runtime.Session;
using Niue.Abp.Zero.Abp.Zero.Authorization.Users;

namespace Niue.Abp.Zero.Abp.Zero.Runtime.Session
{
    public static class AbpSessionExtensions
    {
        public static bool IsUser(this IAbpSession session, AbpUserBase user)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return session.TenantId == user.TenantId && 
                session.UserId.HasValue && 
                session.UserId.Value == user.Id;
        }
    }
}
