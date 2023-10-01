using Architecture.Application.Core.Notifications.Notifiable.Steps.AddNotification;

namespace Architecture.Application.Core.Notifications.Notifiable.Steps.AfterValidationWhen;

public class AfterValidationWhenObject : AfterValidationWhen, IAfterValidationWhen
{
    protected object _currentvalue { get; set; }

    public AfterValidationWhenObject(NotificationContext notificationContext, object value) : base(notificationContext, value)
    {
        _currentvalue = value;
    }

    public AddNotificationService<AfterValidationWhenObject> Is(bool ruleFor)
    {
        return new AddNotificationService<AfterValidationWhenObject>(_notificationContext, ruleFor, _currentvalue);
    }

    public AddNotificationService<AfterValidationWhenObject> IsNull(bool ruleFor)
    {
        return new AddNotificationService<AfterValidationWhenObject>(_notificationContext, ruleFor, _currentvalue == null);
    }
}