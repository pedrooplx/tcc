using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TCC.API.Extensions;
using TCC.API.Extensions.RestResultRepresentation.Models;
using TCC.Application.Models.Organizacao;
using TCC.Application.UseCases.Abstract;

namespace TCC.API.Controllers
{
    [ApiController]
    [Route("analise-expressoes/organizacoes")]
    public class OrganizacoesController : ControllerBase
    {
        private readonly IUseCaseAsync<ObterOrganizacaoPorIdRequest, ObterOrganizacaoPorIdResponse> _obterOrganizacaoPorIdUseCaseAsync;
        private readonly IUseCaseAsync<object, ObterOrganizacoesResponse> _obterOrganizacoesUseCaseAsync;
        private readonly IUseCaseAsync<InserirOrganizacaoRequest> _inserirOrganizacaoUseCaseAsync;
        private readonly IUseCaseAsync<AtualizarOrganizacaoRequest> _atualizarOrganizacaoUseCaseAsync;
        private readonly IUseCaseAsync<RemoverOrganizacaoRequest> _removerOrganizacoesUseCaseAsync;

        public OrganizacoesController(
            IUseCaseAsync<ObterOrganizacaoPorIdRequest, ObterOrganizacaoPorIdResponse> obterOrganizacaoPorIdUseCaseAsync,
            IUseCaseAsync<object, ObterOrganizacoesResponse> obterOrganizacoesUseCaseAsync,
            IUseCaseAsync<InserirOrganizacaoRequest> inserirOrganizacaoUseCaseAsync,
            IUseCaseAsync<AtualizarOrganizacaoRequest> atualizarOrganizacaoUseCaseAsync,
            IUseCaseAsync<RemoverOrganizacaoRequest> removerOrganizacoesUseCaseAsync
            )
        {
            _obterOrganizacaoPorIdUseCaseAsync = obterOrganizacaoPorIdUseCaseAsync;
            _obterOrganizacoesUseCaseAsync = obterOrganizacoesUseCaseAsync;
            _inserirOrganizacaoUseCaseAsync = inserirOrganizacaoUseCaseAsync;
            _atualizarOrganizacaoUseCaseAsync = atualizarOrganizacaoUseCaseAsync;
            _removerOrganizacoesUseCaseAsync = removerOrganizacoesUseCaseAsync;
        }

        [HttpGet("{Id:Guid}")]
        public async Task<IActionResult> ObterOrganizacaoPorId([Required][FromRoute] long id)
        {
            var organizacao = await _obterOrganizacaoPorIdUseCaseAsync.ExecuteAsync(new ObterOrganizacaoPorIdRequest(id));

            return new RestResult<ObterOrganizacaoPorIdResponse>(organizacao, StatusCodeExtensions.Extrair(organizacao));
        }

        [HttpGet]
        public async Task<IActionResult> ObterOrganizacoes()
        {
            var organizacoes = await _obterOrganizacoesUseCaseAsync.ExecuteAsync(default);

            return new RestResult<ObterOrganizacoesResponse>(organizacoes, StatusCodeExtensions.Extrair(organizacoes));
        }

        [HttpPost]
        public async Task<IActionResult> InserirOrganizacao([Required][FromBody] InserirOrganizacaoRequest request)
        {
            await _inserirOrganizacaoUseCaseAsync.ExecuteAsync(request);

            return Ok(request);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarOrganizacao([Required][FromBody] AtualizarOrganizacaoRequest request)
        {
            await _atualizarOrganizacaoUseCaseAsync.ExecuteAsync(request);

            return Ok(request);
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<IActionResult> RemoverOrganizacao([Required][FromRoute] long id)
        {
            await _removerOrganizacoesUseCaseAsync.ExecuteAsync(new RemoverOrganizacaoRequest(id));

            var result = await _obterOrganizacaoPorIdUseCaseAsync.ExecuteAsync(new ObterOrganizacaoPorIdRequest(id));

            return new RestResult<ObterOrganizacaoPorIdResponse>(result, StatusCodeExtensions.Extrair(result));
        }
    }
}