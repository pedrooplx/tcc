using System.ComponentModel.DataAnnotations;
using TCC.Application.Models.Abstract;

namespace TCC.Application.Models.Colaborador
{
    public class ObterColaboradorPorIdRequest : BaseRequest
    {
        [Required]
        public long Id { get; set; }
    }
}
