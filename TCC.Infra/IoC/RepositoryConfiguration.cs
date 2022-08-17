using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TCC.Domain.Gateways;
using TCC.Infra.DataProviders.Repositories;

namespace TCC.Infra.IoC
{
    public static class RepositoryConfiguration
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IAtendimentoGateway, AtendimentoRepository>();
            services.AddScoped<IClassificacaoGateway, ClassificacaoRepository>();
            services.AddScoped<IClienteGateway, ClienteRepository>();
            services.AddScoped<IColaboradorGateway, ColaboradorRepository>();
            services.AddScoped<IOrganizacaoGateway, OrganizacaoRepository>();
        }
    }
}
