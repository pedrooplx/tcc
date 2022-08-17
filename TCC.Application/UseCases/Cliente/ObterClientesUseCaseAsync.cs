﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TCC.Application.Models.Clientes;
using TCC.Application.UseCases.Abstract;
using TCC.Domain.Gateways;

namespace TCC.Application.UseCases.Cliente
{
    public class ObterClientesUseCaseAsync : IUseCaseAsync<object, ObterClientesResponse>
    {
        private readonly ILogger<ObterClientesUseCaseAsync> _logger;
        private readonly IMapper _mapper;
        private readonly IClienteGateway _clientesGateway;

        public ObterClientesUseCaseAsync(ILogger<ObterClientesUseCaseAsync> logger, IMapper mapper, IClienteGateway clientesGateway)
        {
            _logger = logger;
            _mapper = mapper;
            _clientesGateway = clientesGateway;
        }

        public async Task<ObterClientesResponse> ExecuteAsync(object _)
        {
            _logger.LogInformation($"Iniciando busca de clientes");

            var clientes = await _clientesGateway.GetAllAsync();

            return _mapper.Map<ObterClientesResponse>(clientes);
        }
    }
}