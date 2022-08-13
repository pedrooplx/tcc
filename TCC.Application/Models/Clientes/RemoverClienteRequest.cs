using System;
using System.ComponentModel.DataAnnotations;

namespace TCC.Application.Models.Clientes
{
    public class RemoverClienteRequest
    {
        [Required]
        public Guid Id { get; set; }

        public RemoverClienteRequest(Guid id)
        {
            Id = id;
        }
    }
}
