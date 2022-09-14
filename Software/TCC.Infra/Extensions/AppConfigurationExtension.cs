using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TCC.Infra.Configurations;

namespace TCC.Infra.Extensions
{
    public static class AppConfigurationExtension
    {
        public static AppConfigurations RegisterConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseConfiguration>(configuration.GetSection(nameof(DatabaseConfiguration)));
            services.AddScoped(c => c.GetService<IOptionsSnapshot<DatabaseConfiguration>>().Value);

            return services.BuildServiceProvider().GetService<AppConfigurations>();
        }
    }
}