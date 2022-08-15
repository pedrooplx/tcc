﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TCC.Application.Models.Clientes
{
    public class AtualizarClienteRequest
    {
        [Required]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
    }
}
