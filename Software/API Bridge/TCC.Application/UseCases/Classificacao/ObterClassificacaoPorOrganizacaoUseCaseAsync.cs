using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TCC.Application.Models.Classificacao;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Enums;
using TCC.Domain.Gateways;
using TCC.Infra.Helpers.ExceptionsHelper;

namespace TCC.Application.UseCases.Classificacao
{
    public class ObterClassificacaoPorOrganizacaoUseCaseAsync : IUseCaseAsync<ObterClassificacoesPorOrganizacaoRequest, ObterClassificacoesResponse>
    {
        private readonly IClassificacaoGateway _classificacaoGateway;
        private readonly IOrganizacaoGateway _organizacaoGateway;
        private readonly IMapper _mapper;
        public ObterClassificacaoPorOrganizacaoUseCaseAsync(
            IClassificacaoGateway classificacaoGateway,
            IOrganizacaoGateway organizacaoGateway,
            IMapper mapper
        )
        {
            _classificacaoGateway = classificacaoGateway;
            _organizacaoGateway = organizacaoGateway;
            _mapper = mapper;
        }

        public async Task<ObterClassificacoesResponse> ExecuteAsync(ObterClassificacoesPorOrganizacaoRequest request)
        {
            var organizacao = await _organizacaoGateway.ObterOrganizacaoPorCnpj(request.CnpjOrganizacao);

            if (organizacao != null)
            {
                var classificacoes = await _classificacaoGateway.ObterClassificacoesPorOrganizacaoAsync(organizacao.Cnpj);

                var classificacoesMapeadas = _mapper.Map<ObterClassificacoesResponse>(classificacoes);

                return classificacoesMapeadas;
            }

            throw new AppException(ErrosEnum.ORGANIZACAO_NAO_CADASTRADA);
        }
    }
}
