using System;
using System.ComponentModel.DataAnnotations;

namespace TCC.Application.Models.Atendimento
{
    public class ObterAtendimentoPorIdRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
