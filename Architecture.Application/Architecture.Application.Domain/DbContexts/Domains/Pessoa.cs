using Architecture.Application.Domain.Constants;
using Architecture.Application.Domain.DbContexts.Domains.Base;
using Architecture.Application.Domain.DbContexts.ValueObjects;

namespace Architecture.Application.Domain.DbContexts.Domains;

public partial class Pessoa : BaseEntity<Pessoa>
{
    public Nome Nome { get; private set  ; }
    public string Email { get; private set; }
    public DateTime? DataNascimento { get; private set; }
    public Guid EmpregoId { get; private set; }
    public Endereco Endereco { get; private set; } = new Endereco();

    public Pessoa CriarPessoa(string primeiroNome, string sobrenome, string email, DateTime? dataNascimento)
    {
        Set(pessoa => pessoa.Nome, Notifiable<Nome>().CriarNome(primeiroNome, sobrenome));

        Set(pessoa => pessoa.Email, email)
            .ValidateWhen()
            .IsNullOrEmpty().AddNotification(PessoaNotifications.EmailObrigatorio)
            .IsInvalidEmail().AddNotification(PessoaNotifications.EmailObrigatorio);

        Set(pessoa => pessoa.DataNascimento, dataNascimento);

        return this;
    }
}
