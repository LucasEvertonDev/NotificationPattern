using Architecture.Application.Core.Notifications.Services;

namespace Architecture.Application.Core.Notifications.Notifiable.Notifications.Base
{
    public interface INotifiable
    {
        bool IsValid();
        void SetNotificationContext(NotificationContext context);
    }
}