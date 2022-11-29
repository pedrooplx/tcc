using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        private readonly IUseCaseAsync<InserirClassificacaoRequest, List<ObterClassificacaoResponse>> _inserirClassificacaoUseCaseAsync;
        private readonly IUseCaseAsync<ObterClassificacoesPorColaboradorRequest, ObterClassificacoesPorColaboradorResponse> _obterClassificacaoPorColaboradorUseCaseAsync;
        private readonly IUseCaseAsync<AnaliseClassificacaoRequest, List<ObterClassificacaoResponse>> _analiseClassificacaoUseCaseAsync;

        public ClassificacoesController(
            IUseCaseAsync<InserirClassificacaoRequest, List<ObterClassificacaoResponse>> inserirClassificacaoUseCaseAsync,
            IUseCaseAsync<ObterClassificacoesPorColaboradorRequest, ObterClassificacoesPorColaboradorResponse> obterClassificacaoPorColaboradorUseCaseAsync,
            IUseCaseAsync<AnaliseClassificacaoRequest, List<ObterClassificacaoResponse>> analiseClassificacaoUseCaseAsync)
        {
            _inserirClassificacaoUseCaseAsync = inserirClassificacaoUseCaseAsync;
            _obterClassificacaoPorColaboradorUseCaseAsync = obterClassificacaoPorColaboradorUseCaseAsync;
            _analiseClassificacaoUseCaseAsync = analiseClassificacaoUseCaseAsync;
        }

        [HttpGet("colaborador/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterClassificacaoPorColaborador([Required][FromRoute] int id)
        {
            var request = new ObterClassificacoesPorColaboradorRequest(id);

            var classificacoes = await _obterClassificacaoPorColaboradorUseCaseAsync.ExecuteAsync(request);

            return new RestResult<ObterClassificacoesPorColaboradorResponse>(classificacoes, StatusCodeExtensions.Extrair(classificacoes));
        }

        [HttpGet("organizacao/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterClassificacaoPorOrgaizacao([Required][FromRoute] int id)
        {
            var request = new ObterClassificacoesPorColaboradorRequest(id);

            var classificacoes = await _obterClassificacaoPorColaboradorUseCaseAsync.ExecuteAsync(request);

            return new RestResult<ObterClassificacoesPorColaboradorResponse>(classificacoes, StatusCodeExtensions.Extrair(classificacoes));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> InserirClassificacao([Required][FromBody] InserirClassificacaoRequest request)
        {
            var classificacoes = await _inserirClassificacaoUseCaseAsync.ExecuteAsync(request);

            return new RestResult<List<ObterClassificacaoResponse>>(classificacoes, StatusCodeExtensions.Extrair(classificacoes));
        }

        [HttpPost("analise")]
        public async Task<IActionResult> AnaliseClassificacao([Required][FromBody] AnaliseClassificacaoRequest request)
        {
            var classificacoes = await _analiseClassificacaoUseCaseAsync.ExecuteAsync(request);

            return new RestResult<List<ObterClassificacaoResponse>>(classificacoes, StatusCodeExtensions.Extrair(classificacoes));
        }
    }
}