using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TCC.API.Extensions;
using TCC.API.Extensions.RestResultRepresentation.Models;
using TCC.Application.Models.Classificacao;
using TCC.Application.UseCases.Abstract;

namespace TCC.API.Controllers
{
    [ApiController]
    [Route("analise-expressoes/classificacoes")]
    public class ClassificacoesController : Controller
    {
        private readonly IUseCaseAsync<InserirClassificacaoRequest> _inserirClassificacaoUseCaseAsync;
        private readonly IUseCaseAsync<ObterClassificacoesPorColaboradorRequest, ObterClassificacoesPorColaboradorResponse> _obterClassificacaoPorColaboradorUseCaseAsync;

        public ClassificacoesController(
            IUseCaseAsync<InserirClassificacaoRequest> inserirClassificacaoUseCaseAsync,
            IUseCaseAsync<ObterClassificacoesPorColaboradorRequest, ObterClassificacoesPorColaboradorResponse> obterClassificacaoPorColaboradorUseCaseAsync
        )
        {
            _inserirClassificacaoUseCaseAsync = inserirClassificacaoUseCaseAsync;
            _obterClassificacaoPorColaboradorUseCaseAsync = obterClassificacaoPorColaboradorUseCaseAsync;
        }

        [HttpGet("colaboradores/{id}")]
        public async Task<IActionResult> ObterClassificacaoPorColaborador([Required][FromRoute] int id)
        {
            var request = new ObterClassificacoesPorColaboradorRequest(id);

            var classificacoes = await _obterClassificacaoPorColaboradorUseCaseAsync.ExecuteAsync(request);

            return new RestResult<ObterClassificacoesPorColaboradorResponse>(classificacoes, StatusCodeExtensions.Extrair(classificacoes));
        }

        [HttpPost]
        public async Task<IActionResult> InserirClassificacao([Required][FromBody] InserirClassificacaoRequest request)
        {
            await _inserirClassificacaoUseCaseAsync.ExecuteAsync(request);

            return Ok(request);
        }
    }
}
