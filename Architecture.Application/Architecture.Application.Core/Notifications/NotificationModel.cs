namespace Architecture.Application.Core.Notifications;

public class NotificationModel
{
    public NotificationModel(string key, string message)
    {
        this.Key = key;
        this.Message = message;
    }

    public string Key { get; private set; }
    public string Message { get; private set; }
}
