using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TCC.Application.Models.Clientes;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Cliente
{
    public class ObterClientePorIdUseCaseAsync : IUseCaseAsync<ObterClientePorIdRequest, ObterClientePorIdResponse>
    {
        private readonly ILogger<ObterClientePorIdUseCaseAsync> _logger;
        private readonly IMapper _mapper;
        private readonly IClienteGateway _clientesGateway;

        public ObterClientePorIdUseCaseAsync(
            ILogger<ObterClientePorIdUseCaseAsync> logger,
            IMapper mapper,
            IClienteGateway clientesGateway)
        {
            _logger = logger;
            _mapper = mapper;
            _clientesGateway = clientesGateway;
        }

        public async Task<ObterClientePorIdResponse> ExecuteAsync(ObterClientePorIdRequest request)
        {
            _logger.LogInformation($"Iniciando busca de cliente id {request.Id}");

            var response = await _clientesGateway.GetByIdAsync(request.Id);

            return _mapper.Map<ObterClientePorIdResponse>(response);
        }
    }
}
