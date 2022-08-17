using System;
using System.ComponentModel.DataAnnotations;
using TCC.Application.Models.Abstract;

namespace TCC.Application.Models.Atendimento
{
    public class ObterAtendimentoPorIdRequest : BaseRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
