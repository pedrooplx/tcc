using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TCC.Application.Abstract;
using TCC.Application.Models.Clientes;
using TCC.Domain.Entities;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Clientes
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
            Cliente response = await _clientesGateway.GetByIdAsync(request.Id);

            return _mapper.Map<ObterClientePorIdResponse>(response);
        }
    }
}
