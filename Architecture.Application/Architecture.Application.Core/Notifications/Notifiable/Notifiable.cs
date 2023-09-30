using Architecture.Application.Core.Notifications.Context;
using Architecture.Application.Core.Notifications.Services;

namespace Architecture.Application.Core.Notifications.Notifiable;

public class Notifiable : INotifiable
{
    /// <summary>
    /// Notification Context
    /// </summary>
    protected NotificationContext NotificationContext { get; set; }

    /// <summary>
    /// Set Notification Context
    /// </summary>
    /// <param name="context"></param>
    public void SetNotificationContext(NotificationContext context) => NotificationContext = context;

    /// <summary>
    /// Indica se o dominio é válido ou não
    /// </summary>
    /// <returns></returns>
    public bool IsValid()
    {
        return !NotificationContext.HasNotifications;
    }

    /// <summary>
    ///  Trata erros esperados utilizado para melhoria de performance 
    /// </summary>
    /// <returns></returns>
    public ConditionalNotificationsService ValidateWhen()
    {
        return new ConditionalNotificationsService(NotificationContext);
    }


    /// <summary>
    /// Instancia classe para trabalhar com notificationPattern
    /// </summary>
    /// <typeparam name="TNotifiable"></typeparam>
    /// <returns></returns>
    protected TNotifiable Inject<TNotifiable>() where TNotifiable : Notifiable
    {
        var entity = Activator.CreateInstance<TNotifiable>();
        entity.SetNotificationContext(NotificationContext);
        return entity;
    }

    /// Instancia classe para trabalhar com notificationPattern
    /// </summary>
    /// <typeparam name="TNotifiable"></typeparam>
    /// <returns></returns>
    protected TNotifiable InjectVO<TNotifiable>() where TNotifiable : NotifiableValueObject
    {
        var entity = Activator.CreateInstance<TNotifiable>();
        entity.SetNotificationContext(NotificationContext);
        return entity;
    }
}


public record NotifiableValueObject : INotifiable
{
    /// <summary>
    /// Notification Context
    /// </summary>
    protected NotificationContext NotificationContext { get; set; }

    /// <summary>
    /// Set Notification Context
    /// </summary>
    /// <param name="context"></param>
    public void SetNotificationContext(NotificationContext context) => NotificationContext = context;

    /// <summary>
    /// Indica se o dominio é válido ou não
    /// </summary>
    /// <returns></returns>
    public bool IsValid()
    {
        return !NotificationContext.HasNotifications;
    }

    /// <summary>
    ///  Trata erros esperados utilizado para melhoria de performance 
    /// </summary>
    /// <returns></returns>
    public ConditionalNotificationsService ValidateWhen()
    {
        return new ConditionalNotificationsService(NotificationContext);
    }


    /// <summary>
    /// Instancia classe para trabalhar com notificationPattern
    /// </summary>
    /// <typeparam name="TNotifiable"></typeparam>
    /// <returns></returns>
    protected TNotifiable Inject<TNotifiable>() where TNotifiable : Notifiable
    {
        var entity = Activator.CreateInstance<TNotifiable>();
        entity.SetNotificationContext(NotificationContext);
        return entity;
    }
}
