using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TCC.Application.Abstract;
using TCC.Application.Models;

namespace TCC.API.Controllers
{
    [ApiController]
    [Route("analise-expressoes")]
    public class AnaliseExpressoesController : ControllerBase
    {
        private readonly ILogger<AnaliseExpressoesController> _logger;
        private readonly IUseCaseAsync<AnaliseRequest> _analiseUseCaseAsync;

        public AnaliseExpressoesController(ILogger<AnaliseExpressoesController> logger, IUseCaseAsync<AnaliseRequest> analiseUseCaseAsync)
        {
            _logger = logger;
            _analiseUseCaseAsync = analiseUseCaseAsync;
        }

        [HttpGet]
        public async Task<IActionResult> HealthyCheck()
        {
            return Ok("Success");
        }

        [HttpPost]
        public async Task<IActionResult> Analise([Required][FromBody]AnaliseRequest analiseRequest)
        {
            _logger.LogInformation($"Iniciando análise de imagem. Id:{analiseRequest.IdAtendimento}");

            await _analiseUseCaseAsync.ExecuteAsync(analiseRequest);

            return Ok();
        }
        
        //[HttpGet("/colaborador/{funcionalColaborador}")]
        //public async Task<IActionResult> ObterAtendimentosPorColaborador([Required][FromQuery] int funcionalColaborador)
        //{
        //    _logger.LogInformation($"Iniciando busca de registros por colaborador. Funcional:{funcionalColaborador}");

        //    return Ok("Success");
        //}

        //[HttpGet("/organizacao/{idOrganizacao}")]
        //public async Task<IActionResult> ObterAtendimentosPorOrganizacao([Required][FromQuery] Guid idOrganizacao)
        //{
        //    _logger.LogInformation($"Iniciando busca de registros por organização. Organização:{idOrganizacao}");

        //    return Ok("Success");
        //}

        //[HttpGet("/atendimento/{idAtendimento}")]
        //public async Task<IActionResult> ObterAtendimento([Required][FromQuery] Guid idAtendimento)
        //{
        //    _logger.LogInformation($"Iniciando busca de atendimento. IdAtendimento:{idAtendimento}");

        //    return Ok("Success");
        //}
    }
}
