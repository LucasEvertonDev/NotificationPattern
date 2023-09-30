using Architecture.Application.Domain.Domains;
using Architecture.Application.Domain.DTOs.Pessoa;
using Architecture.Application.UseCases.IUseCases;
using Architecture.Application.UseCases.UseCases.Base;

namespace Architecture.Application.UseCases.UseCases.PessoaUseCases
{
    public class CriarPessoaUseCase : BaseUseCase<CriarPessoaModel, PessoaCriadaModel>, ICriarPessoaUseCase
    {
        public CriarPessoaUseCase(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public override Task<PessoaCriadaModel> ExecuteAsync(CriarPessoaModel param)
        {
            var pessoa = Entity<Pessoa>().CriarPessoa(
                nome: param.Nome,
                email: param.Email,
                dataNascimento: param.DataNascimento
            );

            if (!pessoa.IsValid())
            {
                return Task.FromResult(new PessoaCriadaModel());
            }

            return Task.FromResult(new PessoaCriadaModel()
            {
                Message = "Filé demais"
            });
        }
    }
}
