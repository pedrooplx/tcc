using AutoMapper;
using System.Collections.Generic;
using TCC.Application.Models.Classificacao;
using TCC.Domain.Entities;

namespace TCC.Application.Mappers
{
    public class ClassificacaoAutoMapper : Profile
    {
        public ClassificacaoAutoMapper()
        {
            CreateMap<InserirClassificacaoRequest, Classificacao>()
                .ForMember(dest => dest.ColaboradorId, source => source.MapFrom(source => source.ColaboradorId))
                .ForMember(dest => dest.Probabilidade, source => source.MapFrom(source => source.Probabilidade))
                .ForMember(dest => dest.Emocao, source => source.MapFrom(source => source.Emocao));
            
            CreateMap<Classificacao, ObterClassificacaoResponse>()
                .ForMember(dest => dest.Probabilidade, source => source.MapFrom(source => source.Probabilidade))
                .ForMember(dest => dest.Emocao, source => source.MapFrom(source => source.Emocao));

            CreateMap<IEnumerable<Classificacao>, ObterClassificacoesPorColaboradorResponse>()
                .ForMember(dest => dest.Classificacoes, source => source.MapFrom(source => source));
        }
    }
}
