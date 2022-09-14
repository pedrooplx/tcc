using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TCC.Infra.IoC
{
    public static class ServiceCollectionConfiguration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            DbContextConfiguration.RegisterDbContext(services, configuration);
            HealthCheckConfiguration.RegisterHealthCheck(services, configuration);
            SwaggerConfiguration.RegisterSwagger(services);
            RepositoryConfiguration.Register(services);
            UseCaseConfiguration.Register(services);
            AutoMapperConfiguration.ResolveAutoMapper(services);
        }
    }
}
