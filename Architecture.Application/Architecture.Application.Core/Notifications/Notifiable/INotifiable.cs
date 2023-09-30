using Architecture.Application.Core.Notifications.Services;

namespace Architecture.Application.Core.Notifications.Notifiable
{
    public interface INotifiable
    {
        NotificationsService AddNotifications();
        bool IsValid();
        void SetNotificationContext(NotificationContext context);
    }
}