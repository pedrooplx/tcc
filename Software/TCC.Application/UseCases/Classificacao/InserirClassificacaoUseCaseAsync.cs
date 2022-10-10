using AutoMapper;
using System.Threading.Tasks;
using TCC.Application.Models.Classificacao;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;
using TCC.Infra.DataProviders.Services.ExpressionIA;

namespace TCC.Application.UseCases.Classificacao
{
    public class InserirClassificacaoUseCaseAsync : IUseCaseAsync<InserirClassificacaoRequest>
    {
        private readonly IClassificacaoGateway _classificacaoGateway;
        private readonly IMapper _mapper;
        private readonly IColaboradorGateway _colaboradorGateway;
        public InserirClassificacaoUseCaseAsync(
            IClassificacaoGateway classificacaoGateway, 
            IMapper mapper, 
            IColaboradorGateway colaboradorGateway
        )
        {
            _classificacaoGateway = classificacaoGateway;
            _mapper = mapper;
            _colaboradorGateway = colaboradorGateway;
        }

        public async Task ExecuteAsync(InserirClassificacaoRequest request)
        {
            var colaborador = await _colaboradorGateway.ObterColaboradorPorFuncional(request.FuncionalColaborador);

            if (colaborador != null)
            {
                var recognitionResult = await ExpressionIAService.AnalisarFace(request.Imagem);

                if (recognitionResult != null)
                {
                    request.Emocao = recognitionResult.Emotion;
                    request.Probabilidade = recognitionResult.EmotionProbability;
                    request.ColaboradorId = colaborador.Id;

                    var classificacao = _mapper.Map<Domain.Entities.Classificacao>(request);

                    await _classificacaoGateway.InsertAsync(classificacao);
                }
            }

            return;
        }
    }
}
