using AutoMapper;
using System.Collections.Generic;
using TCC.Application.Models.Clientes;
using TCC.Domain.Entities;

namespace TCC.Application.Mappers
{
    public class AutoMapperUseCase : Profile
    {
        public AutoMapperUseCase()
        {
            CreateMap<Cliente, ObterClientePorIdResponse>().ReverseMap();
            CreateMap<InserirClienteRequest, Cliente>().ReverseMap();

            //CreateMap<AtualizarClienteRequest, Cliente>()
            //    .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

            CreateMap<AtualizarClienteRequest, Cliente>()
                                .ForMember(dest => dest.Nome, source => source.MapFrom(source => source.Nome)); //Specific Mapping

        }
    }
}
