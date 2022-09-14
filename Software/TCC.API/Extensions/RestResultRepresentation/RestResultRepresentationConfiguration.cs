using Microsoft.Extensions.DependencyInjection;
using System;

namespace TCC.API.Extensions.RestResultRepresentation
{
    public static class RestResultRepresentationConfiguration
    {
        public static IServiceCollection AddResponseWithPagination(this IServiceCollection services)
        {
            if (services == null)   
                throw new ArgumentNullException(nameof(services));

            //services.AddScoped<PaginationFilter>();

            return services;
        }
    }
}
