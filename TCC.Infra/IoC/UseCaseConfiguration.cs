﻿using Microsoft.Extensions.DependencyInjection;
using TCC.Application.Models.Classificacao;
using TCC.Application.Models.Colaborador;
using TCC.Application.Models.Organizacao;
using TCC.Application.UseCases.Abstract;
using TCC.Application.UseCases.Classificacao;
using TCC.Application.UseCases.Colaborador;
using TCC.Application.UseCases.Organizacao;

namespace TCC.Infra.IoC
{
    public static class UseCaseConfiguration
    {
        public static void Register(this IServiceCollection services)
        {
            RegisterClassificacaoUseCases(services);
            RegisterColaboradorUseCases(services);
            RegisterOrganizacaoUseCases(services);
        }

        private static void RegisterClassificacaoUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUseCaseAsync<InserirClassificacaoRequest>, InserirClassificacaoUseCaseAsync>();
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
