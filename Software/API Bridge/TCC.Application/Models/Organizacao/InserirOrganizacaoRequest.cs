using System.ComponentModel.DataAnnotations;
using TCC.Application.Models.Abstract;

namespace TCC.Application.Models.Organizacao
{
    public class InserirOrganizacaoRequest : BaseRequest
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
