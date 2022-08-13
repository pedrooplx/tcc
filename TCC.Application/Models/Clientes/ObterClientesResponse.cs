using System;

namespace TCC.Application.Models.Clientes
{
    public class ObterClientesResponse
    {
        public Guid Id { get; set; }
        public long Cpf { get; set; }
        public string Nome { get; set; }
    }
}