using System.ComponentModel.DataAnnotations;
using TCC.Application.Models.Abstract;

namespace TCC.Application.Models.Colaborador
{
    public class RemoverColaboradorRequest : BaseRequest
    {
        [Required]
        public long Id { get; set; }
    }
}
