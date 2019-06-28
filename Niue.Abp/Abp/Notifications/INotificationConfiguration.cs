using Niue.Abp.Abp.Collections;

namespace Niue.Abp.Abp.Notifications
{
    /// <summary>
    /// Used to configure notification system.
    /// </summary>
    public interface INotificationConfiguration
    {
        /// <summary>
        /// Notification providers.
        /// </summary>
        ITypeList<NotificationProvider> Providers { get; }
    }
}