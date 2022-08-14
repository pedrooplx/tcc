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
            #region Request
            CreateMap<Cliente, ObterClientePorIdResponse>();

            CreateMap<AtualizarClienteRequest, Cliente>()
                .ForMember(dest => dest.Nome, source => source.MapFrom(source => source.Nome));
            #endregion

            #region Response
            CreateMap<InserirClienteRequest, Cliente>();

            CreateMap<IEnumerable<Cliente>, ObterClientesResponse>()
                .ForMember(dest => dest.Clientes, source => source.MapFrom(source => source));
            #endregion
        }
    }
}
