using AutoMapper;
using System.Collections.Generic;
using TCC.Application.Models.Clientes;
using TCC.Domain.Entities;

namespace TCC.Application.Mappers
{
    public class ClienteAutoMapper : Profile
    {
        public ClienteAutoMapper()
        {
            CreateMap<InserirClienteRequest, Cliente>();
            CreateMap<AtualizarClienteRequest, Cliente>()
                .ForMember(dest => dest.Nome, source => source.MapFrom(source => source.Nome))
                .ForMember(dest => dest.Email, source => source.MapFrom(source => source.Email))
                .ForMember(dest => dest.Endereco, source => source.MapFrom(source => source.Endereco));
            CreateMap<Cliente, ObterClientePorIdResponse>();
            CreateMap<IEnumerable<Cliente>, ObterClientesResponse>()
                .ForMember(dest => dest.Clientes, source => source.MapFrom(source => source));
        }
    }
}
