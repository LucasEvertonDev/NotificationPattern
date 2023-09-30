using System.Text.RegularExpressions;

namespace Architecture.Application.Core.Notifications.Services
{
    public partial class ConditionalNotificationsService 
    {
        private readonly NotificationContext _notificationContext;

        public ConditionalNotificationsService(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public ValidationService Is(bool ruleFor)
        {
            return new ValidationService(_notificationContext, ruleFor);
        }

        public ValidationService IsInvalidEmail(string email)
        {
            return new ValidationService(_notificationContext, !Regex.IsMatch((string)email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"));
        }

        public ValidationService IsNullOrEmpty(string value)
        {
            return new ValidationService(_notificationContext, string.IsNullOrEmpty(value));
        }
    }

    public class ValidationService
    {
        private readonly NotificationContext _notificationContext;
        private readonly bool _includeNotification;

        public ValidationService(NotificationContext notificationContext, bool includeNotification)
        {
            _notificationContext = notificationContext;
            _includeNotification = includeNotification;
        }

        public ConditionalNotificationsService Notification (NotificationModel notification)
        {
            if(_includeNotification)
            {
                _notificationContext.AddNotification(notification);
            }

            return new ConditionalNotificationsService(_notificationContext);
        }
    }
}
