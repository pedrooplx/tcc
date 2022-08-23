using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TCC.Application.Models;
using TCC.Application.Models.Classificacao;
using TCC.Application.UseCases.Abstract;

namespace TCC.Application.UseCases.Classificacao
{
    public class InserirClassificacaoUseCaseAsync : IUseCaseAsync<InserirClassificacaoRequest>
    {
        private readonly ILogger<InserirClassificacaoUseCaseAsync> _logger;

        public InserirClassificacaoUseCaseAsync(ILogger<InserirClassificacaoUseCaseAsync> logger)
        {
            _logger = logger;
        }

        public async Task ExecuteAsync(InserirClassificacaoRequest request)
        {
            var result = await ArtificialInteligence(request.Imagem);

            if (result != null)
            {

            }
        }

        private async Task<AIResponse> ArtificialInteligence(string base64Image)
        {
            return new AIResponse();
        }
    }
}
