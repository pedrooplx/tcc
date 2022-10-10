using AutoMapper;
using System.Threading.Tasks;
using TCC.Application.Models.Classificacao;
using TCC.Application.UseCases.Abstract;
using TCC.Infra.DataProviders.Services.ExpressionIA;

namespace TCC.Application.UseCases.Classificacao
{
    public class AnaliseClassificacaoUseCaseAsync : IUseCaseAsync<AnaliseClassificacaoRequest, ObterClassificacaoResponse>
    {
        private readonly IMapper _mapper;

        public AnaliseClassificacaoUseCaseAsync(
            IMapper mapper
        )
        {
            _mapper = mapper;
        }

        public async Task<ObterClassificacaoResponse> ExecuteAsync(AnaliseClassificacaoRequest request)
        {

            if (request.Imagem != null)
            {
                var recognitionResult = await ExpressionIAService.AnalisarFace(request.Imagem);

                if (recognitionResult != null)
                {
                    request.Emocao = recognitionResult.Emotion;
                    request.Probabilidade = recognitionResult.EmotionProbability;

                    return _mapper.Map<ObterClassificacaoResponse>(request);
                }
            }

            return null;
        }
    }
}
