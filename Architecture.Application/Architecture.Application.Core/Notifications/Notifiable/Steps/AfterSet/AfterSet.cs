namespace Architecture.Application.Core.Notifications.Notifiable.Steps.AfterSet;

public class AfterSet<TNext> where TNext : AfterValidationWhen.AfterValidationWhen
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
        return (TNext)new AfterValidationWhen.AfterValidationWhen(_notificationContext, _value);
    }
}
