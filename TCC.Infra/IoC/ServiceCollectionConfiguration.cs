using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TCC.Infra.IoC
{
    public static class ServiceCollectionConfiguration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            DbContextConfiguration.RegisterDbContext(services, configuration);
            AutoMapperConfiguration.ResolveAutoMapper(services);
            HealthCheckConfiguration.RegisterHealthCheck(services, configuration);
            UseCaseConfiguration.Register(services);
            RepositoryConfiguration.Register(services);
        }
    }
}
