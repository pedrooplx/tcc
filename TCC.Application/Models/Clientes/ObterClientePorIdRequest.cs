using System;
using System.ComponentModel.DataAnnotations;
using TCC.Application.Models.Abstract;

namespace TCC.Application.Models.Clientes
{
    public class ObterClientePorIdRequest : BaseRequest
    {
        [Required]
        public Guid Id { get; set; }

        public ObterClientePorIdRequest(Guid id)
        {
            Id = id;
        }
    }
}
