using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TCC.Application.Abstract;
using TCC.Application.Models;
using TCC.Application.Models.Clientes;
using TCC.Application.UseCases;
using TCC.Application.UseCases.Clientes;
using TCC.Domain.Gateways;
using TCC.Infra.DataProviders;
using TCC.Infra.DataProviders.Repositories;
using TCC.Infra.IOC;

namespace TCC.API
{
    public class Startup
    {
        public IConfiguration configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseMySql(configuration.GetSection("Database:MySqlConnectionString").Value);
                options.EnableSensitiveDataLogging();
            });

            services.AddControllers();

            services.AddScoped<IUseCaseAsync<AnaliseRequest>, AnaliseUseCaseAsync>();

            services.AddScoped<IUseCaseAsync<ObterClientePorIdRequest, ObterClientePorIdResponse>, ObterClientePorIdUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<InserirClienteRequest>, InserirClienteUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<AtualizarClienteRequest>, AtualizarClienteUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<RemoverClienteRequest>, RemoverClienteUseCaseAsync>();

            services.AddScoped<IClienteGateway, ClientesRepository>();
            
            AutoMapperConfiguration.ResolveAutoMapper(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<DataContext>().Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
