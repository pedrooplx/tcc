using AutoMapper;
using System.Threading.Tasks;
using TCC.Application.Models.Classificacao;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Classificacao
{
    public class ObterClassificacaoPorColaboradorUseCaseAsync : IUseCaseAsync<ObterClassificacoesPorColaboradorRequest, ObterClassificacoesResponse>
    {
        private readonly IClassificacaoGateway _classificacaoGateway;
        private readonly IColaboradorGateway _colaboradorGateway;
        private readonly IMapper _mapper;
        public ObterClassificacaoPorColaboradorUseCaseAsync(
            IClassificacaoGateway classificacaoGateway,
            IColaboradorGateway colaboradorGateway,
            IMapper mapper
        )
        {
            _classificacaoGateway = classificacaoGateway;
            _colaboradorGateway = colaboradorGateway;
            _mapper = mapper;
        }

        public async Task<ObterClassificacoesResponse> ExecuteAsync(ObterClassificacoesPorColaboradorRequest request)
        {
            var colaborador = await _colaboradorGateway.ObterColaboradorPorFuncional(request.FuncionalColaborador);

            if (colaborador != null)
            {
                var classificacoes = await _classificacaoGateway.ObterClassificacoesPorColaboradorAsync(colaborador.Id);

                var classificacoesMapeadas = _mapper.Map<ObterClassificacoesResponse>(classificacoes);

                return classificacoesMapeadas;
            }

            return null;

        }
    }
}