using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TCC.Application.Models.Organizacao;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Organizacao
{
    public class ObterOrganizacaoPorIdUseCaseAsync : IUseCaseAsync<ObterOrganizacaoPorIdRequest, ObterOrganizacaoPorIdResponse>
    {
        private readonly ILogger<ObterOrganizacaoPorIdUseCaseAsync> _logger;
        private readonly IMapper _mapper;
        private readonly IOrganizacaoGateway _organizacaoGateway;

        public ObterOrganizacaoPorIdUseCaseAsync(ILogger<ObterOrganizacaoPorIdUseCaseAsync> logger, IMapper mapper, IOrganizacaoGateway organizacaoGateway)
        {
            _logger = logger;
            _mapper = mapper;
            _organizacaoGateway = organizacaoGateway;
        }

        public async Task<ObterOrganizacaoPorIdResponse> ExecuteAsync(ObterOrganizacaoPorIdRequest request)
        {
            _logger.LogInformation($"Iniciando busca de organização {request.Id}");

            var organizacao = await _organizacaoGateway.GetByIdAsync(request.Id);

            return _mapper.Map<ObterOrganizacaoPorIdResponse>(organizacao);
        }
    }
}