using Architecture.Application.Domain.DbContexts.Domains;
using Architecture.Application.Domain.Models.Pessoa;
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
            ///https://balta.io/blog/ef-core-value-objects
            //var nome = InjectVO<Nome>().CreateNome(param.PrimeiroNome, param.Sobrenome);
            //var nomeb = InjectVO<Nome>().CreateNome(param.PrimeiroNome, param.Sobrenome);

            ////if(nome == nomeb)
            ////{

            ////}

            ////var aux  = _notificationContext.Notifications;

            var pessoa = Notify<Pessoa>().CriarPessoa(
                primeiroNome: param.PrimeiroNome,
                sobrenome: param.Sobrenome,
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
