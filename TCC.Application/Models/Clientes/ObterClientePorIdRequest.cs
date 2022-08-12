using System;
using System.ComponentModel.DataAnnotations;

namespace TCC.Application.Models.Clientes
{
    public class ObterClientePorIdRequest
    {
        [Required]
        public Guid Id { get; set; }

        public ObterClientePorIdRequest(Guid id)
        {
            Id = id;
        }
    }
}
