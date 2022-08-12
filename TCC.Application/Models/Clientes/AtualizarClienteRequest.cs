using System.ComponentModel.DataAnnotations;

namespace TCC.Application.Models.Clientes
{
    public class AtualizarClienteRequest
    {
        [Required]
        public string Nome { get; set; }
    }
}
