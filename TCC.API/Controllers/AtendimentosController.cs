using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TCC.API.Extensions;
using TCC.API.Extensions.RestResultRepresentation.Models;
using TCC.Application.Models.Atendimento;
using TCC.Application.UseCases.Abstract;

namespace TCC.API.Controllers
{
    [ApiController]
    [Route("analise-expressoes/atendimentos")]
    public class AtendimentosController : ControllerBase
    {
        private readonly IUseCaseAsync<ObterAtendimentoPorIdRequest, ObterAtendimentoPorIdResponse> _obterAtendimentoPorIdUseCaseAsync;
        private readonly IUseCaseAsync<IniciarAtendimentoRequest> _iniciarAtendimentoPorIdUseCaseAsync;
        private readonly IUseCaseAsync<FinalizarAtendimentoRequest> _finalizarAtendimentoPorIdUseCaseAsync;

        public AtendimentosController(
            IUseCaseAsync<ObterAtendimentoPorIdRequest, ObterAtendimentoPorIdResponse> obterAtendimentoPorIdUseCaseAsync, 
            IUseCaseAsync<IniciarAtendimentoRequest> iniciarAtendimentoPorIdUseCaseAsync, 
            IUseCaseAsync<FinalizarAtendimentoRequest> finalizarAtendimentoPorIdUseCaseAsync
        )
        {
            _obterAtendimentoPorIdUseCaseAsync = obterAtendimentoPorIdUseCaseAsync;
            _iniciarAtendimentoPorIdUseCaseAsync = iniciarAtendimentoPorIdUseCaseAsync;
            _finalizarAtendimentoPorIdUseCaseAsync = finalizarAtendimentoPorIdUseCaseAsync;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterAtendimentoPorId([Required][FromRoute] long id)
        {
            var cliente = await _obterAtendimentoPorIdUseCaseAsync.ExecuteAsync(new ObterAtendimentoPorIdRequest(id));

            return new RestResult<ObterAtendimentoPorIdResponse>(cliente, StatusCodeExtensions.Extrair(cliente));
        }
        
        [HttpPost]
        public async Task<IActionResult> IniciarAtendimento([Required][FromBody] IniciarAtendimentoRequest request)
        {
            await _iniciarAtendimentoPorIdUseCaseAsync.ExecuteAsync(request);

            return Ok(request);
        }

        [HttpPut]
        public async Task<IActionResult> FinalizarAtendimento([Required][FromBody] FinalizarAtendimentoRequest request)
        {
            await _finalizarAtendimentoPorIdUseCaseAsync.ExecuteAsync(request);

            return Ok(request);
        }
    }
}
