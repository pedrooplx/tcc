﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TCC.Application.Models.Clientes
{
    public class AtualizarClienteRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
