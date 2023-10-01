using Architecture.Application.Core.Notifications.Notifiable.Steps.AfterValidationWhen;

namespace Architecture.Application.Core.Notifications.Notifiable.Steps.AfterSet;

public class AfterSet<TNext>
{
    private readonly NotificationContext _notificationContext;
    private readonly dynamic _value;

    public AfterSet(NotificationContext notificationContext, dynamic value)
    {
        _notificationContext = notificationContext;
        _value = value;
    }

    public TNext ValidateWhen()
    {
        return Activator.CreateInstance(typeof(TNext), _notificationContext, _value);
    }
}
