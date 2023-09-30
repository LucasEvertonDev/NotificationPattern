using Architecture.Application.Domain.DTOs.Pessoa;

namespace Architecture.Application.UseCases.IUseCases
{
    public interface ICriarPessoaUseCase
    {
        Task<PessoaCriadaModel> ExecuteAsync(CriarPessoaModel param);
    }
}