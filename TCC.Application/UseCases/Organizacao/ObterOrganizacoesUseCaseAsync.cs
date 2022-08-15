using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TCC.Application.Models.Organizacao;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Organizacao
{
    public class ObterOrganizacoesUseCaseAsync : IUseCaseAsync<object, ObterOrganizacoesResponse>
    {
        private readonly ILogger<ObterOrganizacoesUseCaseAsync> _logger;
        private readonly IMapper _mapper;
        private readonly IOrganizacaoGateway _organizacaoGateway;

        public ObterOrganizacoesUseCaseAsync(ILogger<ObterOrganizacoesUseCaseAsync> logger, IMapper mapper, IOrganizacaoGateway organizacaoGateway)
        {
            _logger = logger;
            _mapper = mapper;
            _organizacaoGateway = organizacaoGateway;
        }

        public async Task<ObterOrganizacoesResponse> ExecuteAsync(object _)
        {
            _logger.LogInformation($"Iniciando busca de organizações");

            var organizacoes = await _organizacaoGateway.GetAllAsync();

            return _mapper.Map<ObterOrganizacoesResponse>(organizacoes);
        }
    }
}
