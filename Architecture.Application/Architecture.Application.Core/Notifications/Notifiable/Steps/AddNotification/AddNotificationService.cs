using Architecture.Application.Core.Notifications.Services;

namespace Architecture.Application.Core.Notifications.Notifiable.Steps.AddNotification;

public class AddNotificationService<TOut> where TOut : AfterValidationWhen.AfterValidationWhen
{
    private readonly NotificationContext _notificationContext;
    private readonly bool _includeNotification;
    private readonly dynamic _value;

    public AddNotificationService(NotificationContext notificationContext, bool includeNotification, dynamic value)
    {
        _notificationContext = notificationContext;
        _includeNotification = includeNotification;
        _value = value;
    }

    public TOut AddNotification(NotificationModel notification)
    {
        if (_includeNotification)
        {
            _notificationContext.AddNotification(notification);
        }

        return (TOut)new AfterValidationWhen.AfterValidationWhen(_notificationContext, _value);
    }
}