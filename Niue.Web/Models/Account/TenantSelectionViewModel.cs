using System.Collections.Generic;
using Niue.Abp.Abp.AutoMapper.AutoMapper;
using Niue.Core.MultiTenancy;

namespace Niue.Web.Models.Account
{
    public class TenantSelectionViewModel
    {
        public string Action { get; set; }

        public List<TenantInfo> Tenants { get; set; }

        [AutoMapFrom(typeof(Tenant))]
        public class TenantInfo
        {
            public int Id { get; set; }

            public string TenancyName { get; set; }

            public string Name { get; set; }
        }
    }
}