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
            CreateMap<Cliente, ObterClientePorIdResponse>();
            CreateMap<InserirClienteRequest, Cliente>();
            CreateMap<AtualizarClienteRequest, Cliente>();
            CreateMap<IEnumerable<Cliente>, ObterClientePorIdResponse>();
        }
    }
}
