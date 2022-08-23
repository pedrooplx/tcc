using AutoMapper;
using System.Collections.Generic;
using TCC.Application.Models.Colaborador;
using TCC.Domain.Entities;

namespace TCC.Application.Mappers
{
    public class ColaboradorAutoMapper : Profile
    {
        public ColaboradorAutoMapper()
        {
            CreateMap<InserirColaboradorRequest, Colaborador>()
                .ForMember(dest => dest.Funcional, source => source.MapFrom(source => source.Funcional))
                .ForMember(dest => dest.Nome, source => source.MapFrom(source => source.Nome))
                .ForMember(dest => dest.Setor, source => source.MapFrom(source => source.Setor));
            //.ForMember(dest => dest.Organizacao.Id, source => source.MapFrom(source => source.IdOrganizacao));

            CreateMap<AtualizarColaboradorRequest, Colaborador>()
                .ForMember(dest => dest.Funcional, source => source.MapFrom(source => source.Funcional))
                .ForMember(dest => dest.Nome, source => source.MapFrom(source => source.Nome))
                .ForMember(dest => dest.Setor, source => source.MapFrom(source => source.Setor));
            //.ForMember(dest => dest.Organizacao.Id, source => source.MapFrom(source => source.IdOrganizacao));

            CreateMap<Colaborador, ObterColaboradorPorIdResponse>()
                .ForMember(dest => dest.Funcional, source => source.MapFrom(source => source.Funcional))
                .ForMember(dest => dest.Nome, source => source.MapFrom(source => source.Nome))
                .ForMember(dest => dest.Setor, source => source.MapFrom(source => source.Setor));
                //.ForMember(dest => dest.Organizacao, source => source.MapFrom(source => source.Organizacao.RazaoSocial));

            CreateMap<IEnumerable<Colaborador>, ObterColaboradoresResponse>()
                .ForMember(dest => dest.Colaboradores, source => source.MapFrom(source => source));
        }
    }
}
