using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TCC.API.Extensions;
using TCC.API.Extensions.RestResultRepresentation.Models;
using TCC.Application.Models.Colaborador;
using TCC.Application.UseCases.Abstract;

namespace TCC.API.Controllers
{
    [ApiController]
    [Route("analise-expressoes/colaboradores")]
    public class ColaboradoresController : ControllerBase
    {
        private readonly IUseCaseAsync<ObterColaboradorPorIdRequest, ObterColaboradorComEmpresaPorIdResponse> _obterColaboradorPorIdUseCaseAsync;
        private readonly IUseCaseAsync<object, ObterColaboradoresComEmpresaResponse> _obterColaboradoresUseCaseAsync;
        private readonly IUseCaseAsync<InserirColaboradorRequest> _inserirColaboradorUseCaseAsync;
        private readonly IUseCaseAsync<AtualizarColaboradorRequest> _atualizarColaboradorUseCaseAsync;
        private readonly IUseCaseAsync<RemoverColaboradorRequest> _removerColaboradorUseCaseAsync;

        public ColaboradoresController(
            IUseCaseAsync<ObterColaboradorPorIdRequest, ObterColaboradorComEmpresaPorIdResponse> obterColaboradorPorIdUseCaseAsync, 
            IUseCaseAsync<object, ObterColaboradoresComEmpresaResponse> obterColaboradoresUseCaseAsync, 
            IUseCaseAsync<InserirColaboradorRequest> inserirColaboradorUseCaseAsync, 
            IUseCaseAsync<AtualizarColaboradorRequest> atualizarColaboradorUseCaseAsync, 
            IUseCaseAsync<RemoverColaboradorRequest> removerColaboradorUseCaseAsync
        )
        {
            _obterColaboradorPorIdUseCaseAsync = obterColaboradorPorIdUseCaseAsync;
            _obterColaboradoresUseCaseAsync = obterColaboradoresUseCaseAsync;
            _inserirColaboradorUseCaseAsync = inserirColaboradorUseCaseAsync;
            _atualizarColaboradorUseCaseAsync = atualizarColaboradorUseCaseAsync;
            _removerColaboradorUseCaseAsync = removerColaboradorUseCaseAsync;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterColaboradorPorId([Required][FromRoute] long id)
        {
            var Colaborador = await _obterColaboradorPorIdUseCaseAsync.ExecuteAsync(new ObterColaboradorPorIdRequest(id));

            return new RestResult<ObterColaboradorComEmpresaPorIdResponse>(Colaborador, StatusCodeExtensions.Extrair(Colaborador));
        }

        [HttpGet]
        public async Task<IActionResult> ObterColaboradors()
        {
            var colaboradores = await _obterColaboradoresUseCaseAsync.ExecuteAsync(default);

            return new RestResult<ObterColaboradoresComEmpresaResponse>(colaboradores, StatusCodeExtensions.Extrair(colaboradores));
        }

        [HttpPost]
        public async Task<IActionResult> InserirColaborador([Required][FromBody] InserirColaboradorRequest request)
        {
            await _inserirColaboradorUseCaseAsync.ExecuteAsync(request);

            return Ok(request);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarColaborador([Required][FromBody] AtualizarColaboradorRequest request)
        {
            await _atualizarColaboradorUseCaseAsync.ExecuteAsync(request);

            return Ok(request);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverColaborador([Required][FromRoute] long id)
        {
            await _removerColaboradorUseCaseAsync.ExecuteAsync(new RemoverColaboradorRequest(id));

            var result = await _obterColaboradorPorIdUseCaseAsync.ExecuteAsync(new ObterColaboradorPorIdRequest(id));

            return new RestResult<ObterColaboradorComEmpresaPorIdResponse>(result, StatusCodeExtensions.Extrair(result));
        }
    }
}
