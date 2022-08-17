using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TCC.Application.UseCases.Abstract;
using TCC.Application.Models.Clientes;
using TCC.API.Extensions.RestResultRepresentation.Models;
using TCC.API.Extensions;

namespace TCC.API.Controllers
{
    [ApiController]
    [Route("analise-expressoes/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly IUseCaseAsync<ObterClientePorIdRequest, ObterClientePorIdResponse> _obterClientePorIdUseCaseAsync;
        private readonly IUseCaseAsync<object, ObterClientesResponse> _obterClientesUseCaseAsync;
        private readonly IUseCaseAsync<InserirClienteRequest> _inserirClienteUseCaseAsync;
        private readonly IUseCaseAsync<AtualizarClienteRequest> _atualizarClienteUseCaseAsync;
        private readonly IUseCaseAsync<RemoverClienteRequest> _removerClientesUseCaseAsync;

        public ClientesController(
            IUseCaseAsync<ObterClientePorIdRequest, ObterClientePorIdResponse> obterClientePorIdUseCaseAsync,
            IUseCaseAsync<object, ObterClientesResponse> obterClientesUseCaseAsync,
            IUseCaseAsync<InserirClienteRequest> inserirClienteUseCaseAsync,
            IUseCaseAsync<AtualizarClienteRequest> atualizarClienteUseCaseAsync, 
            IUseCaseAsync<RemoverClienteRequest> removerClientesUseCaseAsync
            )
        {
            _obterClientePorIdUseCaseAsync = obterClientePorIdUseCaseAsync;
            _obterClientesUseCaseAsync = obterClientesUseCaseAsync;
            _inserirClienteUseCaseAsync = inserirClienteUseCaseAsync;
            _atualizarClienteUseCaseAsync = atualizarClienteUseCaseAsync;
            _removerClientesUseCaseAsync = removerClientesUseCaseAsync;
        }

        [HttpGet("{Id:Guid}")]
        public async Task<IActionResult> ObterClientePorId([Required][FromRoute] Guid id)
        {
            var cliente = await _obterClientePorIdUseCaseAsync.ExecuteAsync(new ObterClientePorIdRequest(id));

            return new RestResult<ObterClientePorIdResponse>(cliente, StatusCodeExtensions.Extrair(cliente));
        }

        [HttpGet]
        public async Task<IActionResult> ObterClientes()
        {
            var clientes = await _obterClientesUseCaseAsync.ExecuteAsync(default);

            return new RestResult<ObterClientesResponse>(clientes, StatusCodeExtensions.Extrair(clientes));
        }

        [HttpPost]
        public async Task<IActionResult> InserirCliente([Required][FromBody] InserirClienteRequest request)
        {
            await _inserirClienteUseCaseAsync.ExecuteAsync(request);

            return Ok(request);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarCliente([Required][FromBody] AtualizarClienteRequest request)
        {
            await _atualizarClienteUseCaseAsync.ExecuteAsync(request);

            return Ok(request);
        }

        [HttpDelete("{Id:Guid}")]
        public async Task<IActionResult> RemoverCliente([Required][FromRoute] Guid id)
        {
            await _removerClientesUseCaseAsync.ExecuteAsync(new RemoverClienteRequest(id));

            var result = await _obterClientePorIdUseCaseAsync.ExecuteAsync(new ObterClientePorIdRequest(id));

            if (result == null)
                return NotFound();
            
            return Ok(result);
        }
    }
}