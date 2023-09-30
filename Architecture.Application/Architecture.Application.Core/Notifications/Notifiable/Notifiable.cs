using Architecture.Application.Core.Notifications.Services;

namespace Architecture.Application.Core.Notifications.Notifiable;

public class Notifiable : INotifiable
{
    private NotificationContext NotificationContext { get; set; }

    public void SetNotificationContext(NotificationContext context) => NotificationContext = context;

    /// <summary>
    /// Indica se o dominio é válido ou não
    /// </summary>
    /// <returns></returns>
    public bool IsValid()
    {
        return !NotificationContext.HasNotifications;
    }

    public NotificationsService AddNotifications()
    {
        return new NotificationsService(NotificationContext);
    }
}
