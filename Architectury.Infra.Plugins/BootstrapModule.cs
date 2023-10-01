using Architecture.Application.Core.Structure;
using Architectury.Infra.Plugins.FluentValidation.Pessoa;
using Microsoft.Extensions.DependencyInjection;

namespace Architectury.Infra.Plugins;

public static class BootstrapModule
{
    public static void AddPlugins(this IServiceCollection services, AppSettings configuration)
    {
        services.AddScoped<CriarPessoaValidator>();
    }
}
