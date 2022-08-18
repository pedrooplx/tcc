using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TCC.Application.Models.Colaborador;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Colaborador
{
    public class ObterColaboradoresUseCaseAsync : IUseCaseAsync<object, ObterColaboradoresResponse>
    {
        private readonly ILogger<ObterColaboradoresUseCaseAsync> _logger;
        private readonly IMapper _mapper;
        private readonly IColaboradorGateway _ColaboradorGateway;

        public ObterColaboradoresUseCaseAsync(ILogger<ObterColaboradoresUseCaseAsync> logger, IMapper mapper, IColaboradorGateway ColaboradorGateway)
        {
            _logger = logger;
            _mapper = mapper;
            _ColaboradorGateway = ColaboradorGateway;
        }

        public async Task<ObterColaboradoresResponse> ExecuteAsync(object _)
        {
            _logger.LogInformation($"Iniciando busca de organizações");

            var organizacoes = await _ColaboradorGateway.GetAllAsync();

            return _mapper.Map<ObterColaboradoresResponse>(organizacoes);
        }
    }
}
