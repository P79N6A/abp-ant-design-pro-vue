using Niue.Abp.Abp.Collections;

namespace Niue.Abp.Zero.Abp.Zero.Zero.Configuration
{
    /// <summary>
    /// User management configuration.
    /// </summary>
    public interface IUserManagementConfig
    {
        ITypeList<object> ExternalAuthenticationSources { get; set; }
    }
}