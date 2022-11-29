using AutoMapper;
using System;
using System.Collections.Generic;
using TCC.Application.Models.Classificacao;
using TCC.Domain.Entities;
using TCC.Domain.Enums;
using TCC.Domain.Extensions;

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

            CreateMap<IEnumerable<Classificacao>, ObterClassificacoesResponse>()
                .ForMember(dest => dest.Classificacoes, source => source.MapFrom(source => source));

            CreateMap<AnaliseClassificacaoRequest, ObterClassificacaoResponse>();

            CreateMap<Tuple<string, double>, ObterClassificacaoResponse>()
                .ForMember(dest => dest.Emocao, source => source.MapFrom(source => EnumExtension.GetDescription((EmocoesEnum)Enum.Parse(typeof(EmocoesEnum), source.Item1))))
                .ForMember(dest => dest.Probabilidade, source => source.MapFrom(source => source.Item2));
        }
    }
}