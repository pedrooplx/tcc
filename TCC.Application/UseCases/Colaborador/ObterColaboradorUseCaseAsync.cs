using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TCC.Application.Models.Colaborador;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Colaborador
{
    public class ObterColaboradorUseCaseAsync : IUseCaseAsync<object, ObterColaboradoresResponse>
    {
        private readonly ILogger<ObterColaboradorUseCaseAsync> _logger;
        private readonly IMapper _mapper;
        private readonly IColaboradorGateway _ColaboradorGateway;

        public ObterColaboradorUseCaseAsync(ILogger<ObterColaboradorUseCaseAsync> logger, IMapper mapper, IColaboradorGateway ColaboradorGateway)
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
