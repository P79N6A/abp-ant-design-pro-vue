using System.Data.Common;
using System.Data.Entity;
using Niue.Abp.Zero.Abp.Zero.EntityFramework.Zero.EntityFramework;
using Niue.Core.Authorization.RolePermissions;
using Niue.Core.Authorization.Roles;
using Niue.Core.Entities.Agents;
using Niue.Core.Entities.Cities;
using Niue.Core.Entities.Schools;
using Niue.Core.MultiTenancy;
using Niue.Core.Routers;
using Niue.Core.Users;

namespace Niue.EntityFramework.EntityFramework
{
    public class NiueDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Add-Migration Initial -Verbose
        //TODO: Update-Database -Verbose
        public virtual IDbSet<Router> Routers { get; set; }
        public virtual IDbSet<RolePermission> RoleRouterPermissions { get; set; }
        public virtual IDbSet<City> Cities { get; set; }

        //TODO: Define an IDbSet for your Entities...
        public virtual IDbSet<Agent> Agents { get; set; }
        public virtual IDbSet<School> Schools { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public NiueDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in NiueDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of NiueDbContext since ABP automatically handles it.
         */
        public NiueDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public NiueDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
