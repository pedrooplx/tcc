using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TCC.Application.Models.Colaborador;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Colaborador
{
    public class ObterColaboradorPorIdUseCaseAsync : IUseCaseAsync<ObterColaboradorPorIdRequest, ObterColaboradorPorIdResponse>
    {
        private readonly ILogger<ObterColaboradorPorIdUseCaseAsync> _logger;
        private readonly IMapper _mapper;
        private readonly IColaboradorGateway _ColaboradorGateway;

        public ObterColaboradorPorIdUseCaseAsync(ILogger<ObterColaboradorPorIdUseCaseAsync> logger, IMapper mapper, IColaboradorGateway ColaboradorGateway)
        {
            _logger = logger;
            _mapper = mapper;
            _ColaboradorGateway = ColaboradorGateway;
        }

        public async Task<ObterColaboradorPorIdResponse> ExecuteAsync(ObterColaboradorPorIdRequest request)
        {
            _logger.LogInformation($"Iniciando busca de organização {request.Id}");

            var Colaborador = await _ColaboradorGateway.GetByIdAsync(request.Id);

            return _mapper.Map<ObterColaboradorPorIdResponse>(Colaborador);
        }
    }
}