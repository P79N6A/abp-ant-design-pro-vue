using EntityFramework.DynamicFilters;
using Niue.EntityFramework.EntityFramework;

namespace Niue.EntityFramework.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly NiueDbContext _context;

        public InitialHostDbBuilder(NiueDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
            new DefaultRouterCreator(_context).Create();
            new DefaultCityCreator(_context).Create();
        }
    }
}
