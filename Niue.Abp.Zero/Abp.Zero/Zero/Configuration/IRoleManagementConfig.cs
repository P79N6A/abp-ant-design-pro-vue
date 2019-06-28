using System.Collections.Generic;

namespace Niue.Abp.Zero.Abp.Zero.Zero.Configuration
{
    public interface IRoleManagementConfig
    {
        List<StaticRoleDefinition> StaticRoles { get; }
    }
}