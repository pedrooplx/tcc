using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TCC.Application.Models.Clientes;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Cliente
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
            _logger.LogInformation($"Iniciando atualização de cliente id {request.Id}");

            var clienteAtual = await _clienteGateway.GetByIdAsync(request.Id);
            
            var clienteAtualizado = _mapper.Map(request, clienteAtual);

            await _clienteGateway.UpdateAsync(clienteAtualizado);
        }
    }
}
