using Microsoft.Extensions.DependencyInjection;
using TCC.Application.Models.Atendimento;
using TCC.Application.Models.Classificacao;
using TCC.Application.Models.Clientes;
using TCC.Application.Models.Colaborador;
using TCC.Application.Models.Organizacao;
using TCC.Application.UseCases.Abstract;
using TCC.Application.UseCases.Atendimento;
using TCC.Application.UseCases.Classificacao;
using TCC.Application.UseCases.Cliente;
using TCC.Application.UseCases.Colaborador;
using TCC.Application.UseCases.Organizacao;

namespace TCC.Infra.IoC
{
    public static class UseCaseConfiguration
    {
        public static void Register(this IServiceCollection services)
        {
            RegisterAtendimentoUseCases(services);
            RegisterClassificacaoUseCases(services);
            RegisterClienteUseCases(services);
            RegisterColaboradorUseCases(services);
            RegisterOrganizacaoUseCases(services);
        }

        private static void RegisterAtendimentoUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseAsync<ObterAtendimentoPorIdRequest, ObterAtendimentoPorIdResponse>, ObterAtendimentoPorIdUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<IniciarAtendimentoRequest>, IniciarAtendimentoUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<FinalizarAtendimentoRequest>, FinalizarAtendimentoUseCaseAsync>();
        }

        private static void RegisterClassificacaoUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseAsync<InserirClassificacaoRequest>, InserirClassificacaoUseCaseAsync>();
        }

        private static void RegisterClienteUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseAsync<ObterClientePorIdRequest, ObterClientePorIdResponse>, ObterClientePorIdUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<object, ObterClientesResponse>, ObterClientesUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<InserirClienteRequest>, InserirClienteUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<AtualizarClienteRequest>, AtualizarClienteUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<RemoverClienteRequest>, RemoverClienteUseCaseAsync>();
        }

        private static void RegisterColaboradorUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseAsync<ObterColaboradorPorIdRequest, ObterColaboradorPorIdResponse>, ObterColaboradorPorIdUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<object, ObterColaboradoresResponse>, ObterColaboradoresUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<InserirColaboradorRequest>, InserirColaboradorUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<AtualizarColaboradorRequest>, AtualizarColaboradorUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<RemoverColaboradorRequest>, RemoverColaboradorUseCaseAsync>();
        }

        private static void RegisterOrganizacaoUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseAsync<ObterOrganizacaoPorIdRequest, ObterOrganizacaoPorIdResponse>, ObterOrganizacaoPorIdUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<object, ObterOrganizacoesResponse>, ObterOrganizacoesUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<InserirOrganizacaoRequest>, InserirOrganizacaoUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<AtualizarOrganizacaoRequest>, AtualizarOrganizacaoUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<RemoverOrganizacaoRequest>, RemoverOrganizacaoUseCaseAsync>();
        }
    }
}
