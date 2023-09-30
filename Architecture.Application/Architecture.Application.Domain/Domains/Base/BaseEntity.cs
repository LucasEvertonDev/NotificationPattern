using Architecture.Application.Core.Notifications.Notifiable;

namespace Architecture.Application.Domain.Domains.Base;

public partial class BaseEntity : Notifiable, IEntity
{
    public Guid Id { get; protected set; }

    public int Situation { get; protected set; }
}
