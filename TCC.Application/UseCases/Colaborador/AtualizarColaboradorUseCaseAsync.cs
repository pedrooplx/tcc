using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TCC.Application.Models.Colaborador;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Colaborador
{
    public class AtualizarColaboradorUseCaseAsync : IUseCaseAsync<AtualizarColaboradorRequest>
    {
        private readonly ILogger<AtualizarColaboradorUseCaseAsync> _logger;
        private readonly IMapper _mapper;
        private readonly IColaboradorGateway _ColaboradorGateway;

        public AtualizarColaboradorUseCaseAsync(ILogger<AtualizarColaboradorUseCaseAsync> logger, IMapper mapper, IColaboradorGateway ColaboradorGateway)
        {
            _logger = logger;
            _mapper = mapper;
            _ColaboradorGateway = ColaboradorGateway;
        }

        public async Task ExecuteAsync(AtualizarColaboradorRequest request)
        {
            _logger.LogInformation($"Iniciando atualização de Colaborador {request}");

            var Colaborador = _mapper.Map<Domain.Entities.Colaborador>(request);

            await _ColaboradorGateway.UpdateAsync(Colaborador);
        }
    }
}
