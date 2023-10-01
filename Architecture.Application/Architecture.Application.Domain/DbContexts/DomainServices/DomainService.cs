using Architecture.Application.Core.Notifications.Notifiable.Notifications;

namespace Architecture.Application.Domain.DbContexts.DomainServices;

public class DomainService : Notifiable
{
    protected readonly NotificationContext _notificationContext;

    public DomainService(NotificationContext notificationContext)
    {
        _notificationContext = notificationContext;
    }
}