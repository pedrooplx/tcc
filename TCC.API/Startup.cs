using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Xml;
using TCC.Application.Models.Clientes;
using TCC.Application.Models.Organizacao;
using TCC.Application.UseCases.Abstract;
using TCC.Application.UseCases.Cliente;
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
            //Database
            services.AddDbContext<DataContext>(options =>
            {
                options.UseMySql(configuration.GetSection("Database:MySqlConnectionString").Value);
                options.EnableSensitiveDataLogging();
            });

            //HC
            services.AddHealthChecks()
                .AddMySql(configuration.GetSection("Database:MySqlConnectionString").Value)
                .AddDbContextCheck<DataContext>();

            //

            services.AddControllers();

            //Use Cases
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
            else
            {
                app.UseHsts();
            }

            //Ativa o HealthChecks
            app.UseHealthChecks("/health", new HealthCheckOptions()
            {
                ResponseWriter = (httpContext, result) => {
                    httpContext.Response.ContentType = "application/json";

                    var json = new JObject(
                        new JProperty("status", result.Status.ToString()),
                        new JProperty("results", new JObject(result.Entries.Select(pair =>
                            new JProperty(pair.Key, new JObject(
                                new JProperty("status", pair.Value.Status.ToString()),
                                new JProperty("description", pair.Value.Description),
                                new JProperty("data", new JObject(pair.Value.Data.Select(
                                    p => new JProperty(p.Key, p.Value))))))))));
                    return httpContext.Response.WriteAsync(json.ToString((Newtonsoft.Json.Formatting)Formatting.Indented));
                }
            });

            //

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
