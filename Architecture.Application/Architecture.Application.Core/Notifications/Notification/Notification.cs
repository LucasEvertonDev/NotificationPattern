using System.Linq.Expressions;

namespace Architecture.Application.Core.Notifications.Notification;

public class Notification
{
    private NotificationContext NotificationContext { get; set; }

    public void SetNotificationContext(NotificationContext context) => NotificationContext = context;

    /// <summary>
    /// Quando true registra o erro em notifcation context 
    /// </summary>
    /// <param name="ruleToError"></param>
    /// <param name="notification"></param>
    /// <returns></returns>
    protected Notification RuleFor(bool ruleToError, NotificationModel notification)
    {
        if (ruleToError)
        {
            NotificationContext.AddNotification(notification);
        }
        return this;
    }

    /// <summary>
    /// Indica se o dominio é válido ou não
    /// </summary>
    /// <returns></returns>
    public bool IsValid()
    {
        return !NotificationContext.HasNotifications;
    }
}
