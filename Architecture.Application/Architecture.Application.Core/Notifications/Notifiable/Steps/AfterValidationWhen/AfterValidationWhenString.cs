using Architecture.Application.Core.Notifications.Notifiable.Steps.AddNotification;
using System.Text.RegularExpressions;

namespace Architecture.Application.Core.Notifications.Notifiable.Steps.AfterValidationWhen;

public class AfterValidationWhenString : AfterValidationWhen, IAfterValidationWhen
{
    protected string _currentvalue { get; set; }

    public AfterValidationWhenString(NotificationContext notificationContext, string value) : base(notificationContext, value)
    {
        _currentvalue = value;
    }

    public AddNotificationService<AfterValidationWhenString> Is(bool ruleFor)
    {
        return new AddNotificationService<AfterValidationWhenString>(_notificationContext, ruleFor, _currentvalue);
    }

    public AddNotificationService<AfterValidationWhenString> IsNull(bool ruleFor)
    {
        return new AddNotificationService<AfterValidationWhenString>(_notificationContext, ruleFor, _currentvalue == null);
    }

    public AddNotificationService<AfterValidationWhenString> IsInvalidEmail()
    {
        return new AddNotificationService<AfterValidationWhenString>(_notificationContext, !Regex.IsMatch(_currentvalue, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"), _currentvalue);
    }

    public AddNotificationService<AfterValidationWhenString> IsNullOrEmpty()
    {
        return new AddNotificationService<AfterValidationWhenString>(_notificationContext, string.IsNullOrEmpty(_currentvalue), _currentvalue);
    }

    public AddNotificationService<AfterValidationWhenString> MinLength(int minLenght)
    {
        return new AddNotificationService<AfterValidationWhenString>(_notificationContext, _currentvalue?.Length < minLenght, _currentvalue);
    }

    public AddNotificationService<AfterValidationWhenString> MaxLenght(int maxLenght)
    {
        return new AddNotificationService<AfterValidationWhenString>(_notificationContext, _currentvalue?.Length > maxLenght, _currentvalue);
    }
}
