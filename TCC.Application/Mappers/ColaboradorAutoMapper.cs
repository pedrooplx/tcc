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
            CreateMap<InserirColaboradorRequest, Colaborador>();
            CreateMap<AtualizarColaboradorRequest, Colaborador>();
            CreateMap<Colaborador, ObterColaboradorComEmpresaPorIdResponse>()
                .ForMember(dest => dest.Organizacao, source => source.MapFrom(source => source.Organizacao.RazaoSocial));
            CreateMap<IEnumerable<Colaborador>, ObterColaboradoresComEmpresaResponse>()
                .ForMember(dest => dest.Colaboradores, source => source.MapFrom(source => source));
        }
    }
}
