using Architecture.Application.Core.Notifications.Notification;

namespace Architecture.Application.Domain.Entities.Base;

public partial class BaseEntity : Notification, IEntity
{
    public Guid Id { get; protected set; }

    public int Situation { get; protected set; }
}
