using Architecture.Application.Core.Notifications.Notifiable.Steps.AddNotification;

namespace Architecture.Application.Core.Notifications.Notifiable.Steps.AfterValidationWhen;

public class AfterValidationWhen
{
    protected readonly NotificationContext _notificationContext;
    protected readonly dynamic _value;

    public AfterValidationWhen(NotificationContext notificationContext, dynamic value)
    {
        _notificationContext = notificationContext;
        _value = value;
    }
}
