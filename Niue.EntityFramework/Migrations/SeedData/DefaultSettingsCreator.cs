using System.Linq;
using Niue.Abp.Abp.Localization;
using Niue.Abp.Abp.Net.Mail;
using Niue.Abp.Zero.Abp.Zero.Configuration;
using Niue.EntityFramework.EntityFramework;

namespace Niue.EntityFramework.Migrations.SeedData
{
    public class DefaultSettingsCreator
    {
        private readonly NiueDbContext _context;

        public DefaultSettingsCreator(NiueDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            //Emailing
            AddSettingIfNotExists(EmailSettingNames.DefaultFromAddress, "admin@mydomain.com");
            AddSettingIfNotExists(EmailSettingNames.DefaultFromDisplayName, "mydomain.com mailer");

            //Languages
            AddSettingIfNotExists(LocalizationSettingNames.DefaultLanguage, "en");
        }

        private void AddSettingIfNotExists(string name, string value, int? tenantId = null)
        {
            if (_context.Settings.Any(s => s.Name == name && s.TenantId == tenantId && s.UserId == null))
            {
                return;
            }

            _context.Settings.Add(new Setting(tenantId, null, name, value));
            _context.SaveChanges();
        }
    }
}