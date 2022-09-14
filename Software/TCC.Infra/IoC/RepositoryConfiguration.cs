using Microsoft.Extensions.DependencyInjection;
using TCC.Domain.Gateways;
using TCC.Infra.DataProviders.Repositories;

namespace TCC.Infra.IoC
{
    public static class RepositoryConfiguration
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IClassificacaoGateway, ClassificacaoRepository>();
            services.AddScoped<IColaboradorGateway, ColaboradorRepository>();
            services.AddScoped<IOrganizacaoGateway, OrganizacaoRepository>();
        }
    }
}
