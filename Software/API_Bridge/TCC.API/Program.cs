using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace TCC.API
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            var hostEnvironment = host.Services.GetService<IHostEnvironment>();

            logger.LogInformation($"Inicializando serviço 'TCC.API' em {DateTime.Now}. Environment: {hostEnvironment.EnvironmentName}");

            return host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(ConfigureAppConfiguration)
                .ConfigureWebHost(ConfigureWebHost);

        }

        private static void ConfigureAppConfiguration(HostBuilderContext context, IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .AddJsonFile("appsettings.json", true, true);
        }

        private static void ConfigureWebHost(IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseKestrel(option =>
            {
                option.Limits.KeepAliveTimeout = TimeSpan.FromMilliseconds(30000);
                option.Limits.RequestHeadersTimeout = TimeSpan.FromMilliseconds(30000);
            });
            webHostBuilder.UseStartup<Startup>();
        }
    }
}
