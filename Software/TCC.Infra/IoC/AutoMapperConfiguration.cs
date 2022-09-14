using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TCC.Application.Mappers;

namespace TCC.Infra.IoC
{
    public static class AutoMapperConfiguration
    {
        public static void ResolveAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ClassificacaoAutoMapper());
                cfg.AddProfile(new ColaboradorAutoMapper());
                cfg.AddProfile(new OrganizacaoAutoMapper());
            });
            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
