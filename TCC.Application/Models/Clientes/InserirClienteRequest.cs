using System.ComponentModel.DataAnnotations;
using TCC.Application.Models.Abstract;

namespace TCC.Application.Models.Clientes
{
    public class InserirClienteRequest : BaseRequest
    {
        [Required]
        public long Cpf { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Endereco { get; set; }
    }
}
