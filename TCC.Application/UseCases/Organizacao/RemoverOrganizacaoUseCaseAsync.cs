using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TCC.Application.Models.Organizacao;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Organizacao
{
    public class RemoverOrganizacaoUseCaseAsync : IUseCaseAsync<RemoverOrganizacaoRequest>
    {
        private readonly ILogger<RemoverOrganizacaoUseCaseAsync> _logger;
        private readonly IMapper _mapper;
        private readonly IOrganizacaoGateway _organizacaoGateway;

        public RemoverOrganizacaoUseCaseAsync(ILogger<RemoverOrganizacaoUseCaseAsync> logger, IMapper mapper, IOrganizacaoGateway organizacaoGateway)
        {
            _logger = logger;
            _mapper = mapper;
            _organizacaoGateway = organizacaoGateway;
        }

        public async Task ExecuteAsync(RemoverOrganizacaoRequest request)
        {
            _logger.LogInformation($"Iniciando remoção de organizacao id{request.Id}");

            var organizacao = _mapper.Map<Domain.Entities.Organizacao>(request);

            await _organizacaoGateway.DeleteAsync(request.Id);
        }
    }
}
