using Microsoft.Extensions.DependencyInjection;
using TCC.Application.Models.Clientes;
using TCC.Application.Models.Organizacao;
using TCC.Application.UseCases.Abstract;
using TCC.Application.UseCases.Cliente;
using TCC.Application.UseCases.Organizacao;

namespace TCC.Infra.IoC
{
    public static class UseCaseConfiguration
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseAsync<ObterClientePorIdRequest, ObterClientePorIdResponse>, ObterClientePorIdUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<object, ObterClientesResponse>, ObterClientesUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<InserirClienteRequest>, InserirClienteUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<AtualizarClienteRequest>, AtualizarClienteUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<RemoverClienteRequest>, RemoverClienteUseCaseAsync>();

            services.AddScoped<IUseCaseAsync<ObterOrganizacaoPorIdRequest, ObterOrganizacaoPorIdResponse>, ObterOrganizacaoPorIdUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<object, ObterOrganizacoesResponse>, ObterOrganizacoesUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<InserirOrganizacaoRequest>, InserirOrganizacaoUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<AtualizarOrganizacaoRequest>, AtualizarOrganizacaoUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<RemoverOrganizacaoRequest>, RemoverOrganizacaoUseCaseAsync>();
        }
    }
}
