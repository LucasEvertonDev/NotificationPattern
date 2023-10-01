using Architecture.Application.Core.Notifications.Notifiable.Notifications;
using Architecture.Application.Core.Notifications.Notifiable.Steps.Start;

namespace Architecture.Application.Domain.DbContexts.Domains.Base;

public partial class BaseEntity : Notifiable, IEntity
{
    public Guid Id { get; protected set; }

    public int Situation { get; protected set; }
}


public partial class BaseEntity<TEntity> : DomainNotifiable<TEntity>, IEntity
{
    public Guid Id { get; protected set; }

    public int Situation { get; protected set; }
}
