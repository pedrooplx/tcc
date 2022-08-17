using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TCC.Application.Models.Colaborador;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Colaborador
{
    public class InserirColaboradorUseCaseAsync : IUseCaseAsync<InserirColaboradorRequest>
    {
        private readonly ILogger<InserirColaboradorUseCaseAsync> _logger;
        private readonly IMapper _mapper;
        private readonly IColaboradorGateway _ColaboradorGateway;

        public InserirColaboradorUseCaseAsync(ILogger<InserirColaboradorUseCaseAsync> logger, IMapper mapper, IColaboradorGateway ColaboradorGateway)
        {
            _logger = logger;
            _mapper = mapper;
            _ColaboradorGateway = ColaboradorGateway;
        }

        public async Task ExecuteAsync(InserirColaboradorRequest request)
        {
            _logger.LogInformation($"Iniciando criação de Colaborador {request}");

            var Colaborador = _mapper.Map<Domain.Entities.Colaborador>(request);

            await _ColaboradorGateway.InsertAsync(Colaborador);
        }
    }
}
