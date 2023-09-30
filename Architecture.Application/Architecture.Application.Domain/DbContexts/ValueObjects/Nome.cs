using Architecture.Application.Core.Notifications.Notifiable;

namespace Architecture.Application.Domain.DbContexts.ValueObjects;

public record Nome : NotifiableValueObject
{
    public Nome() { }

    public string PrimeiroNome { get; private set; }
    public string Sobrenome { get; private set; }


    public string NomeCompleto() => string.Concat(PrimeiroNome, " ", Sobrenome);

    public Nome CreateNome(string primeiroNome, string sobrenome)
    {
        ValidateWhen()
           .IsNullOrEmpty(primeiroNome).Notification(new NotificationModel("PRIMEIRO_NOME", "Primeiro nome é obrigatório"))
           .IsNullOrEmpty(sobrenome).Notification(new NotificationModel("SOBRENOME", "SobreNome é obrigatório"));

        PrimeiroNome = primeiroNome;
        Sobrenome = sobrenome;

        return this;
    }
}
