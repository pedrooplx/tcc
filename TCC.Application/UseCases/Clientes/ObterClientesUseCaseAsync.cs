using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCC.Application.Abstract;
using TCC.Application.Models.Clientes;
using TCC.Domain.Entities;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Clientes
{
    public class ObterClientesUseCaseAsync : IUseCaseAsync<IEnumerable<ObterClientePorIdResponse>>
    {
        private readonly ILogger<ObterClientesUseCaseAsync> _logger;
        private readonly IMapper _mapper;
        private readonly IClienteGateway _clientesGateway;

        public ObterClientesUseCaseAsync(
            ILogger<ObterClientesUseCaseAsync> logger,
            IMapper mapper,
            IClienteGateway clientesGateway)
        {
            _logger = logger;
            _mapper = mapper;
            _clientesGateway = clientesGateway;
        }

        public async Task ExecuteAsync(IEnumerable<ObterClientePorIdResponse> request)
        {
            var response = await _clientesGateway.GetAllAsync();

            return _mapper.Map<ObterClientePorIdResponse>(response);
        }
    }
}
