using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace TCC.Infra.IoC
{
    public static class SwaggerConfiguration
    {
        public static void RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Análise de Expressões", Version = "v1" });
            });
        }

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoAPI V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
