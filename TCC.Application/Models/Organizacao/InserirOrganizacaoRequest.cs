using System.ComponentModel.DataAnnotations;

namespace TCC.Application.Models.Organizacao
{
    public class InserirOrganizacaoRequest
    {
        [Required]
        public string RazaoSocial { get; set; }
        [Required]
        public int Cnpj { get; set; }
        [Required]
        public double Patrimonio { get; set; }
        [Required]
        public string Area { get; set; }
    }
}
