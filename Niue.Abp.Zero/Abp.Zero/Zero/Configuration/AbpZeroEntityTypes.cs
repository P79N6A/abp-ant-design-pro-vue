using System;
using Niue.Abp.Abp;
using Niue.Abp.Zero.Abp.Zero.Authorization.Roles;
using Niue.Abp.Zero.Abp.Zero.Authorization.Users;
using Niue.Abp.Zero.Abp.Zero.MultiTenancy;

namespace Niue.Abp.Zero.Abp.Zero.Zero.Configuration
{
    public class AbpZeroEntityTypes : IAbpZeroEntityTypes
    {
        public Type User
        {
            get { return _user; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (!typeof (AbpUserBase).IsAssignableFrom(value))
                {
                    throw new AbpException(value.AssemblyQualifiedName + " should be derived from " + typeof(AbpUserBase).AssemblyQualifiedName);
                }

                _user = value;
            }
        }
        private Type _user;

        public Type Role
        {
            get { return _role; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (!typeof(AbpRoleBase).IsAssignableFrom(value))
                {
                    throw new AbpException(value.AssemblyQualifiedName + " should be derived from " + typeof(AbpRoleBase).AssemblyQualifiedName);
                }

                _role = value;
            }
        }
        private Type _role;

        public Type Tenant
        {
            get { return _tenant; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (!typeof(AbpTenantBase).IsAssignableFrom(value))
                {
                    throw new AbpException(value.AssemblyQualifiedName + " should be derived from " + typeof(AbpTenantBase).AssemblyQualifiedName);
                }

                _tenant = value;
            }
        }
        private Type _tenant;
    }
}