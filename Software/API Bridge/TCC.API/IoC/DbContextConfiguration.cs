using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TCC.Infra.DataProviders;

namespace TCC.Infra.IoC
{
    public static class DbContextConfiguration
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseMySql(configuration.GetSection("Database:MySqlConnectionString").Value);
                options.EnableSensitiveDataLogging();
            });
        }
    }
}
