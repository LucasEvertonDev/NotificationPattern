using System.Text.RegularExpressions;

namespace Architecture.Application.Core.Notifications.Services
{
    public partial class NotificationsService 
    {
        private readonly NotificationContext _notificationContext;

        public NotificationsService(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public NotificationsService If(bool ruleFor, NotificationModel notificationModel)
        {
            if (ruleFor)
            {
                _notificationContext.AddNotification(notificationModel);
            }

            return this;
        }

        public NotificationsService IfIsInvalidEmail(string email, NotificationModel notificationModel)
        {
            if (!Regex.IsMatch((string)email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
            {
                _notificationContext.AddNotification(notificationModel);
            }
            return this;
        }

        public NotificationsService IfIsNullOrEmpty(string value, NotificationModel notificationModel)
        {
            if (string.IsNullOrEmpty(value))
            {
                _notificationContext.AddNotification(notificationModel);
            }
            return this;
        }
    }
}
