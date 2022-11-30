using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TCC.Application.Models.Colaborador;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Colaborador
{
    public class ObterColaboradorComEmpresaPorIdUseCaseAsync : IUseCaseAsync<ObterColaboradorPorIdRequest, ObterColaboradorComEmpresaPorIdResponse>
    {
        private readonly ILogger<ObterColaboradorComEmpresaPorIdUseCaseAsync> _logger;
        private readonly IMapper _mapper;
        private readonly IColaboradorGateway _ColaboradorGateway;

        public ObterColaboradorComEmpresaPorIdUseCaseAsync(ILogger<ObterColaboradorComEmpresaPorIdUseCaseAsync> logger, IMapper mapper, IColaboradorGateway ColaboradorGateway)
        {
            _logger = logger;
            _mapper = mapper;
            _ColaboradorGateway = ColaboradorGateway;
        }

        public async Task<ObterColaboradorComEmpresaPorIdResponse> ExecuteAsync(ObterColaboradorPorIdRequest request)
        {
            _logger.LogInformation($"Iniciando busca de organização {request.Id}");

            var colaborador = await _ColaboradorGateway.ObterColaboradorComEmpresaPorIdAsync(request.Id);

            return _mapper.Map<ObterColaboradorComEmpresaPorIdResponse>(colaborador);
        }
    }
}