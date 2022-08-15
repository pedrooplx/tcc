using System;
using System.Collections.Generic;

namespace TCC.Application.Models.Clientes
{
    public class ObterClientePorIdResponse
    {
        public Guid Id { get; set; }
        public long Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
    }
}