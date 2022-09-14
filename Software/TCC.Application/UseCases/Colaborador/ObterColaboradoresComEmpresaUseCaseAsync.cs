using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TCC.Application.Models.Colaborador;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Colaborador
{
    public class ObterColaboradoresComEmpresaUseCaseAsync : IUseCaseAsync<object, ObterColaboradoresComEmpresaResponse>
    {
        private readonly ILogger<ObterColaboradoresComEmpresaUseCaseAsync> _logger;
        private readonly IMapper _mapper;
        private readonly IColaboradorGateway _ColaboradorGateway;

        public ObterColaboradoresComEmpresaUseCaseAsync(ILogger<ObterColaboradoresComEmpresaUseCaseAsync> logger, IMapper mapper, IColaboradorGateway ColaboradorGateway)
        {
            _logger = logger;
            _mapper = mapper;
            _ColaboradorGateway = ColaboradorGateway;
        }

        public async Task<ObterColaboradoresComEmpresaResponse> ExecuteAsync(object _)
        {
            _logger.LogInformation($"Iniciando busca de organizações");

            var colaboradores = await _ColaboradorGateway.ObterColaboradoresComEmpresaAsync();

            return _mapper.Map<ObterColaboradoresComEmpresaResponse>(colaboradores);
        }
    }
}