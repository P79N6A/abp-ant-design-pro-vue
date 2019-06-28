using System.Collections.Generic;
using Niue.Abp.Abp.Application.Navigation;

namespace Niue.Abp.Abp.Web.Common.Web.Models.AbpUserConfiguration
{
    public class AbpUserNavConfigDto
    {
        public Dictionary<string, UserMenu> Menus { get; set; }
    }
}