using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TCC.Application.Models.Colaborador;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Colaborador
{
    public class RemoverColaboradorUseCaseAsync : IUseCaseAsync<RemoverColaboradorRequest>
    {
        private readonly ILogger<RemoverColaboradorUseCaseAsync> _logger;
        private readonly IMapper _mapper;
        private readonly IColaboradorGateway _ColaboradorGateway;

        public RemoverColaboradorUseCaseAsync(ILogger<RemoverColaboradorUseCaseAsync> logger, IMapper mapper, IColaboradorGateway ColaboradorGateway)
        {
            _logger = logger;
            _mapper = mapper;
            _ColaboradorGateway = ColaboradorGateway;
        }

        public async Task ExecuteAsync(RemoverColaboradorRequest request)
        {
            _logger.LogInformation($"Iniciando remoção de colaborador id{request.Id}");

            var Colaborador = _mapper.Map<Domain.Entities.Colaborador>(request);

            await _ColaboradorGateway.DeleteAsync(request.Id);
        }
    }
}
