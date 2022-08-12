using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TCC.Application.Abstract;
using TCC.Application.Models.Clientes;
using TCC.Application.UseCases.Clientes;
using TCC.Domain.Gateways;

namespace TCC.API.Controllers
{
    [ApiController]
    [Route("analise-expressoes/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly IUseCaseAsync<ObterClientePorIdRequest, ObterClientePorIdResponse> _obterClientePorIdUseCaseAsync;
        private readonly IUseCaseAsync<InserirClienteRequest> _inserirClienteUseCaseAsync;
        private readonly IUseCaseAsync<AtualizarClienteRequest> _atualizarClienteUseCaseAsync;

        public ClientesController(
            ILogger<ClientesController> logger, 
            IUseCaseAsync<ObterClientePorIdRequest, ObterClientePorIdResponse> obterClientePorIdUseCaseAsync, 
            IUseCaseAsync<InserirClienteRequest> inserirClienteUseCaseAsync, 
            IUseCaseAsync<AtualizarClienteRequest> atualizarClienteUseCaseAsync
        )
        {
            _logger = logger;
            _obterClientePorIdUseCaseAsync = obterClientePorIdUseCaseAsync;
            _inserirClienteUseCaseAsync = inserirClienteUseCaseAsync;
            _atualizarClienteUseCaseAsync = atualizarClienteUseCaseAsync;
        }

        [HttpGet("{Id:Guid}")]
        public async Task<IActionResult> ObterClientePorId([Required] Guid id)
        {
            return Ok(await _obterClientePorIdUseCaseAsync.ExecuteAsync(new ObterClientePorIdRequest(id)));
        }

        [HttpGet]
        public async Task<IActionResult> ObterClientes()
        {
            return Ok("Success");
        }

        [HttpPost]
        public async Task<IActionResult> InserirCliente([Required] InserirClienteRequest request)
        {
            await _inserirClienteUseCaseAsync.ExecuteAsync(request);

            return Ok(request);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarCliente([Required] AtualizarClienteRequest request)
        {
            await _atualizarClienteUseCaseAsync.ExecuteAsync(request);

            return Ok(request);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverCliente()
        {
            return Ok("Success");
        }
    }
}
