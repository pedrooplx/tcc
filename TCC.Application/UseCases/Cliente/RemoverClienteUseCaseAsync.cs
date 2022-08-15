using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TCC.Application.Models.Clientes;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Cliente
{
    public class RemoverClienteUseCaseAsync : IUseCaseAsync<RemoverClienteRequest>
    {
        private readonly ILogger<ObterClientePorIdUseCaseAsync> _logger;
        private readonly IClienteGateway _clientesGateway;

        public RemoverClienteUseCaseAsync(
            ILogger<ObterClientePorIdUseCaseAsync> logger,
            IClienteGateway clientesGateway)
        {
            _logger = logger;
            _clientesGateway = clientesGateway;
        }

        public async Task ExecuteAsync(RemoverClienteRequest request)
        {
            _logger.LogInformation($"Iniciando exclusão de cliente id {request.Id}");
            await _clientesGateway.DeleteAsync(request.Id);
        }
    }
}
