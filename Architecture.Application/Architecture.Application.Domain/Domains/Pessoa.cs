using Architecture.Application.Domain.Constants;
using Architecture.Application.Domain.Domains.Base;

namespace Architecture.Application.Domain.Domains;

public partial class Pessoa : BaseEntity
{
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public DateTime? DataNascimento { get; private set; }

    public Pessoa CriarPessoa(string nome, string email, DateTime? dataNascimento)
    {
        AddNotifications()
           .If(string.IsNullOrEmpty(nome), PessoaValidations.NomeObrigatorio)
           .IfIsNullOrEmpty(email, PessoaValidations.EmailObrigatorio)
           .IfIsInvalidEmail(email, PessoaValidations.EmailInválido);

        Nome = nome;
        Email = email;
        DataNascimento = dataNascimento;

        return this;
    }
}
