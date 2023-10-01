using Architecture.Application.Core.Notifications.Notifiable.Steps.AfterValidationWhen;

namespace Architecture.Application.Core.Notifications.Notifiable.Steps.AddNotification;

public class AddNotificationService<TOut> where TOut : IAfterValidationWhen
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

        return Activator.CreateInstance(typeof(TOut), _notificationContext, _value);
    }
}