using Architecture.Application.Domain.Constants;
using Architecture.Application.Domain.DbContexts.Domains.Base;
using Architecture.Application.Domain.DbContexts.ValueObjects;

namespace Architecture.Application.Domain.DbContexts.Domains;

public partial class Pessoa : BaseEntity
{
    public Nome Nome { get; set; }
    public string Email { get; private set; }
    public DateTime? DataNascimento { get; private set; }
    public Guid EmpregoId { get; set; }

    public Pessoa CriarPessoa(string primeiroNome, string sobrenome, string email, DateTime? dataNascimento)
    {
        ValidateWhen()
           .IsNullOrEmpty(email)
                .Notification(PessoaNotifications.EmailObrigatorio)
           .IsInvalidEmail(email)
                .Notification(PessoaNotifications.EmailInvalido);

        this.Nome = InjectVO<Nome>().CreateNome(primeiroNome, sobrenome);
        this.Email = email;
        this.DataNascimento = dataNascimento;

        return this;
    }
}
