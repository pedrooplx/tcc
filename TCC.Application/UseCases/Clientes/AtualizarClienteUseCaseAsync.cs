using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TCC.Application.Abstract;
using TCC.Application.Models.Clientes;
using TCC.Domain.Entities;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Clientes
{
    public class AtualizarClienteUseCaseAsync : IUseCaseAsync<AtualizarClienteRequest>
    {
        private readonly ILogger<AtualizarClienteUseCaseAsync> _logger;
        private readonly IMapper _mapper;
        private readonly IClienteGateway _clienteGateway;

        public AtualizarClienteUseCaseAsync(ILogger<AtualizarClienteUseCaseAsync> logger, IMapper mapper, IClienteGateway clienteGateway)
        {
            _logger = logger;
            _mapper = mapper;
            _clienteGateway = clienteGateway;
        }

        public async Task ExecuteAsync(AtualizarClienteRequest request)
        {
            var cliente = _mapper.Map<Cliente>(request);

            await _clienteGateway.UpdateAsync(cliente);
        }
    }
}
