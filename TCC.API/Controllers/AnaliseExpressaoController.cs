using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TCC.Application.Abstract;
using TCC.Application.Models;

namespace TCC.API.Controllers
{
    [ApiController]
    [Route("analise-expressao")]
    public class AnaliseExpressaoController : ControllerBase
    {
        private readonly ILogger<AnaliseExpressaoController> _logger;
        private readonly IUseCaseAsync<AnaliseRequest> _analiseUseCaseAsync;

        public AnaliseExpressaoController(ILogger<AnaliseExpressaoController> logger)
        {
            _logger = logger;
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
