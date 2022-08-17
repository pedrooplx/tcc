using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using TCC.Infra.DataProviders;

namespace TCC.Infra.IoC
{
    public static class HealthCheckConfiguration
    {
        public static void RegisterHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddMySql(configuration.GetSection("Database:MySqlConnectionString").Value)
                .AddDbContextCheck<DataContext>();
        }
        public static void ConfigureHealthCheck(this IApplicationBuilder app)
        {
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
                    return httpContext.Response.WriteAsync(json.ToString(Formatting.Indented));
                }
            });
        }
    }
}
