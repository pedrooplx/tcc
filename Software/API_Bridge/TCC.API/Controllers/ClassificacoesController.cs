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
        private readonly IUseCaseAsync<InserirClassificacaoRequest, List<InserirClassificacaoResponse>> _inserirClassificacaoUseCaseAsync;
        private readonly IUseCaseAsync<ObterClassificacoesPorColaboradorRequest, ObterClassificacoesResponse> _obterClassificacaoPorColaboradorUseCaseAsync;
        private readonly IUseCaseAsync<ObterClassificacoesPorOrganizacaoRequest, ObterClassificacoesResponse> _obterClassificacaoPorOrganizacaoUseCaseAsync;
        private readonly IUseCaseAsync<AnaliseClassificacaoRequest, List<ObterClassificacaoResponse>> _analiseClassificacaoUseCaseAsync;
        
        public ClassificacoesController(
            IUseCaseAsync<InserirClassificacaoRequest, List<InserirClassificacaoResponse>> inserirClassificacaoUseCaseAsync,
            IUseCaseAsync<ObterClassificacoesPorColaboradorRequest, ObterClassificacoesResponse> obterClassificacaoPorColaboradorUseCaseAsync,
            IUseCaseAsync<ObterClassificacoesPorOrganizacaoRequest, ObterClassificacoesResponse> obterClassificacaoPorOrganizacaoUseCaseAsync,
            IUseCaseAsync<AnaliseClassificacaoRequest, List<ObterClassificacaoResponse>> analiseClassificacaoUseCaseAsync)
        {
            _inserirClassificacaoUseCaseAsync = inserirClassificacaoUseCaseAsync;
            _obterClassificacaoPorColaboradorUseCaseAsync = obterClassificacaoPorColaboradorUseCaseAsync;
            _obterClassificacaoPorOrganizacaoUseCaseAsync = obterClassificacaoPorOrganizacaoUseCaseAsync;
            _analiseClassificacaoUseCaseAsync = analiseClassificacaoUseCaseAsync;
        }

        [HttpGet("colaborador/{funcional}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterClassificacaoPorColaborador([Required][FromRoute] int funcional)
        {
            var request = new ObterClassificacoesPorColaboradorRequest(funcional);

            var classificacoes = await _obterClassificacaoPorColaboradorUseCaseAsync.ExecuteAsync(request);

            return new RestResult<ObterClassificacoesResponse>(classificacoes, StatusCodeExtensions.Extrair(classificacoes));
        }

        [HttpGet("organizacao/{cnpj}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterClassificacaoPorOrgaizacao([Required][FromRoute] int cnpj)
        {
            var request = new ObterClassificacoesPorOrganizacaoRequest(cnpj);

            var classificacoes = await _obterClassificacaoPorOrganizacaoUseCaseAsync.ExecuteAsync(request);

            return new RestResult<ObterClassificacoesResponse>(classificacoes, StatusCodeExtensions.Extrair(classificacoes));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> InserirClassificacao([Required][FromBody] InserirClassificacaoRequest request)
        {
            var classificacoes = await _inserirClassificacaoUseCaseAsync.ExecuteAsync(request);

            return new RestResult<List<InserirClassificacaoResponse>>(classificacoes, StatusCodeExtensions.Extrair(classificacoes));
        }

        [HttpPost("analise")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AnaliseClassificacao([Required][FromBody] AnaliseClassificacaoRequest request)
        {
            var classificacoes = await _analiseClassificacaoUseCaseAsync.ExecuteAsync(request);

            return new RestResult<List<ObterClassificacaoResponse>>(classificacoes, StatusCodeExtensions.Extrair(classificacoes));
        }
    }
}