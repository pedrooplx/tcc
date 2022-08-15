using AutoMapper;
using System.Collections.Generic;
using TCC.Application.Models.Organizacao;
using TCC.Domain.Entities;

namespace TCC.Application.Mappers
{
    public class OrganizacaoAutoMapper : Profile
    {
        public OrganizacaoAutoMapper()
        {
            CreateMap<InserirOrganizacaoRequest, Organizacao>();
            CreateMap<AtualizarOrganizacaoRequest, Organizacao>()
                .ForMember(dest => dest.RazaoSocial, source => source.MapFrom(source => source.RazaoSocial))
                .ForMember(dest => dest.Patrimonio, source => source.MapFrom(source => source.Patrimonio))
                .ForMember(dest => dest.Area, source => source.MapFrom(source => source.Area));
            CreateMap<Organizacao, ObterOrganizacaoPorIdResponse>();
            CreateMap<IEnumerable<Organizacao>, ObterOrganizacoesResponse>()
                .ForMember(dest => dest.Organizacoes, source => source.MapFrom(source => source));
        }
    }
}
