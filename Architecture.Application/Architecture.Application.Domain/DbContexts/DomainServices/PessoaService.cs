using Architecture.Application.Core.Notifications.Context;
using Architecture.Application.Domain.DbContexts.DomainServices.Interfaces;

namespace Architecture.Application.Domain.DbContexts.DomainServices;

public class PessoaService : DomainService, IPessoaService
{
    public PessoaService(NotificationContext notificationContext) : base(notificationContext)
    {
    }
}
