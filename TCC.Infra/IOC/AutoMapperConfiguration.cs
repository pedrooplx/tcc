using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TCC.Application.Mappers;

namespace TCC.Infra.IOC
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection ResolveAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperUseCase());
            });
            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
