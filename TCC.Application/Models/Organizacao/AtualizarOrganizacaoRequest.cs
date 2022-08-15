using System;
using System.ComponentModel.DataAnnotations;

namespace TCC.Application.Models.Organizacao
{
    public class AtualizarOrganizacaoRequest
    {
        [Required]
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public double Patrimonio { get; set; }
        public string Area { get; set; }
    }
}
