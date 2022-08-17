using System;
using System.ComponentModel.DataAnnotations;
using TCC.Application.Models.Abstract;

namespace TCC.Application.Models.Clientes
{
    public class RemoverClienteRequest : BaseRequest
    {
        [Required]
        public Guid Id { get; set; }

        public RemoverClienteRequest(Guid id)
        {
            Id = id;
        }
    }
}
