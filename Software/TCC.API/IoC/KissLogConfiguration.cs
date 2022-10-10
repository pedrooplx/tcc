using KissLog.AspNetCore;
using KissLog.CloudListeners.RequestLogsListener;
using KissLog.Formatters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TCC.Infra.IoC
{
    public static class KissLoggerConfiguration
    {
        public static void RegisterKissLog(this IServiceCollection services)
        {
            services.AddLogging(logging =>
            {
                logging.AddKissLog(options =>
                {
                    options.Formatter = (FormatterArgs args) =>
                    {
                        if (args.Exception == null)
                            return args.DefaultValue;

                        string exceptionStr = new ExceptionFormatter().Format(args.Exception, args.Logger);

                        return string.Join(Environment.NewLine, new[] { args.DefaultValue, exceptionStr });
                    };
                });
            });
        }
        public static void ConfigureKissLog(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseKissLogMiddleware(options => ConfigureKissLog(options, configuration));
        }

        private static void ConfigureKissLog(IOptionsBuilder options, IConfiguration configuration)
        {
            KissLog.KissLogConfiguration.Listeners.Add(new RequestLogsApiListener(new KissLog.CloudListeners.Auth.Application(
                configuration["KissLog.OrganizationId"],
                configuration["KissLog.ApplicationId"])
            )
            {
                ApiUrl = configuration["KissLog.ApiUrl"]
            });
        }
    }
}
