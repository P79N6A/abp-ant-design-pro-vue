using System.Linq;
using Niue.Core.MultiTenancy;
using Niue.EntityFramework.EntityFramework;

namespace Niue.EntityFramework.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly NiueDbContext _context;

        public DefaultTenantCreator(NiueDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
