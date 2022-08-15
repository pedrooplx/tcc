using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TCC.Application.Models;
using TCC.Application.Models.Clientes;
using TCC.Application.Models.Organizacao;
using TCC.Application.UseCases;
using TCC.Application.UseCases.Abstract;
using TCC.Application.UseCases.Clientes;
using TCC.Application.UseCases.Organizacao;
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
            //DB
            services.AddDbContext<DataContext>(options =>
            {
                options.UseMySql(configuration.GetSection("Database:MySqlConnectionString").Value);
                options.EnableSensitiveDataLogging();
            });

            services.AddControllers();

            //Use Cases
            services.AddScoped<IUseCaseAsync<AnaliseRequest>, AnaliseUseCaseAsync>();

            services.AddScoped<IUseCaseAsync<ObterClientePorIdRequest, ObterClientePorIdResponse>, ObterClientePorIdUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<object, ObterClientesResponse>, ObterClientesUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<InserirClienteRequest>, InserirClienteUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<AtualizarClienteRequest>, AtualizarClienteUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<RemoverClienteRequest>, RemoverClienteUseCaseAsync>();

            services.AddScoped<IUseCaseAsync<ObterOrganizacaoPorIdRequest, ObterOrganizacaoPorIdResponse>, ObterOrganizacaoPorIdUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<object, ObterOrganizacoesResponse>, ObterOrganizacoesUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<InserirOrganizacaoRequest>, InserirOrganizacaoUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<AtualizarOrganizacaoRequest>, AtualizarOrganizacaoUseCaseAsync>();
            services.AddScoped<IUseCaseAsync<RemoverOrganizacaoRequest>, RemoverOrganizacaoUseCaseAsync>();

            //Repository
            services.AddScoped<IAtendimentoGateway, AtendimentoRepository>();
            services.AddScoped<IClassificacaoGateway, ClassificacaoRepository>();
            services.AddScoped<IClienteGateway, ClienteRepository>();
            services.AddScoped<IColaboradorGateway, ColaboradorRepository>();
            services.AddScoped<IOrganizacaoGateway, OrganizacaoRepository>();
            
            //Services
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
