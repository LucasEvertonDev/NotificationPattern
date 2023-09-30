using Architecture.Application.Domain.DTOs.Pessoa;
using Architecture.Application.Domain.Entities;
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

            var aux = this.GetNotifications();

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
