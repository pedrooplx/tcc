using System;
using System.ComponentModel.DataAnnotations;
using TCC.Application.Models.Abstract;

namespace TCC.Application.Models.Organizacao
{
    public class AtualizarOrganizacaoRequest : BaseRequest
    {
        [Required]
        public long Id { get; set; }
        public string RazaoSocial { get; set; }
        public double Patrimonio { get; set; }
        public string Area { get; set; }
    }
}
