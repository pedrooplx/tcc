using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TCC.Application.Models.Organizacao;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Organizacao
{
    public class InserirOrganizacaoUseCaseAsync : IUseCaseAsync<InserirOrganizacaoRequest>
    {
        private readonly ILogger<InserirOrganizacaoUseCaseAsync> _logger;
        private readonly IMapper _mapper;
        private readonly IOrganizacaoGateway _organizacaoGateway;

        public InserirOrganizacaoUseCaseAsync(ILogger<InserirOrganizacaoUseCaseAsync> logger, IMapper mapper, IOrganizacaoGateway organizacaoGateway)
        {
            _logger = logger;
            _mapper = mapper;
            _organizacaoGateway = organizacaoGateway;
        }

        public async Task ExecuteAsync(InserirOrganizacaoRequest request)
        {
            _logger.LogInformation($"Iniciando criação de organizacao {request}");

            var organizacao = _mapper.Map<Domain.Entities.Organizacao>(request);

            await _organizacaoGateway.InsertAsync(organizacao);
        }
    }
}
