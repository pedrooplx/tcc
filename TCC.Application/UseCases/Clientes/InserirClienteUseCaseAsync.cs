using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TCC.Application.UseCases.Abstract;
using TCC.Application.Models.Clientes;
using TCC.Domain.Entities;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Clientes
{
    public class InserirClienteUseCaseAsync : IUseCaseAsync<InserirClienteRequest>
    {
        private readonly ILogger<InserirClienteUseCaseAsync> _logger;
        private readonly IMapper _mapper;
        private readonly IClienteGateway _clienteGateway;

        public InserirClienteUseCaseAsync(ILogger<InserirClienteUseCaseAsync> logger, IMapper mapper, IClienteGateway clienteGateway)
        {
            _logger = logger;
            _mapper = mapper;
            _clienteGateway = clienteGateway;
        }

        public async Task ExecuteAsync(InserirClienteRequest request)
        {
            _logger.LogInformation($"Iniciando criação de cliente {request.Cpf}");

            var cliente = _mapper.Map<Cliente>(request);

            await _clienteGateway.InsertAsync(cliente);
        }
    }
}
