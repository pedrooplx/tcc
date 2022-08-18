using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TCC.Application.Models.Classificacao;
using TCC.Application.UseCases.Abstract;

namespace TCC.API.Controllers
{
    [ApiController]
    [Route("analise-expressoes/classificacoes")]
    public class ClassificacoesController : Controller
    {
        private readonly IUseCaseAsync<InserirClassificacaoRequest> _inserirClassificacaoUseCaseAsync;

        public ClassificacoesController(
            IUseCaseAsync<InserirClassificacaoRequest> inserirClassificacaoUseCaseAsync
        )
        {
            _inserirClassificacaoUseCaseAsync = inserirClassificacaoUseCaseAsync;
        }

        [HttpPost]
        public async Task<IActionResult> InserirClassificacao([Required][FromBody] InserirClassificacaoRequest request)
        {
            await _inserirClassificacaoUseCaseAsync.ExecuteAsync(request);

            return Ok(request);
        }
    }
}
