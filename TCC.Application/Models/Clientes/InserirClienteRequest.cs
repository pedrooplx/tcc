using System.ComponentModel.DataAnnotations;

namespace TCC.Application.Models.Clientes
{
    public class InserirClienteRequest
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
