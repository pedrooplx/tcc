using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TCC.API.Middlewares;
using TCC.Infra.DataProviders;
using TCC.Infra.Extensions;
using TCC.Infra.IoC;

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
            services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    JsonSerializerExtension.SnakeCaseNamingPolicySerializer(options);
                });

            services.AddHttpContextAccessor();

            ServiceCollectionConfiguration.RegisterServices(services, configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //{
            //    serviceScope.ServiceProvider.GetRequiredService<DataContext>().Database.Migrate();
            //}

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();

            HealthCheckConfiguration.ConfigureHealthCheck(app);
            SwaggerConfiguration.ConfigureSwagger(app);
            KissLoggerConfiguration.ConfigureKissLog(app, configuration);

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
