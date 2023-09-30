using Architecture.Application.Domain.Constants;
using Architecture.Application.Domain.Entities.Base;

namespace Architecture.Application.Domain.Entities;

public partial class Pessoa : BaseEntity
{
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public DateTime? DataNascimento { get; private set; }

    public Pessoa CriarPessoa(string nome, string email, DateTime? dataNascimento)
    {
        RuleFor(string.IsNullOrEmpty(nome), PessoaValidations.NomeObrigatorio);
        RuleFor(string.IsNullOrEmpty(email), PessoaValidations.EmailObrigatorio);

        Nome = nome;
        Email = email;
        DataNascimento = dataNascimento;

        return this;
    }

}
