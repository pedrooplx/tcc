using Microsoft.Extensions.DependencyInjection;
using TCC.Domain.Gateways.Services;
using TCC.Infra.DataProviders.Services;

namespace TCC.API.IoC
{
    public static class ServicesConfiguration
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddSingleton<IConsultarIAGateway, ConsultarIAService>();
        }
    }
}
