using Niue.Abp.Abp.Domain.Uow;
using Niue.Abp.Abp.Web.Models;

namespace Niue.Abp.Abp.Web.Mvc.Web.Mvc.Configuration
{
    public class AbpMvcConfiguration : IAbpMvcConfiguration
    {
        public UnitOfWorkAttribute DefaultUnitOfWorkAttribute { get; }

        public WrapResultAttribute DefaultWrapResultAttribute { get; }

        public bool IsValidationEnabledForControllers { get; set; }

        public bool IsAutomaticAntiForgeryValidationEnabled { get; set; }

        public bool IsAuditingEnabled { get; set; }

        public bool IsAuditingEnabledForChildActions { get; set; }

        public AbpMvcConfiguration()
        {
            DefaultUnitOfWorkAttribute = new UnitOfWorkAttribute();
            DefaultWrapResultAttribute = new WrapResultAttribute();
            IsValidationEnabledForControllers = true;
            IsAutomaticAntiForgeryValidationEnabled = true;
            IsAuditingEnabled = true;
        }
    }
}