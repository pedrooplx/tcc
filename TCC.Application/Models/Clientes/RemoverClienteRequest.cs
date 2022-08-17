using System;
using System.ComponentModel.DataAnnotations;
using TCC.Application.Models.Abstract;

namespace TCC.Application.Models.Clientes
{
    public class RemoverClienteRequest : BaseRequest
    {
        [Required]
        public long Id { get; set; }

        public RemoverClienteRequest(long id)
        {
            Id = id;
        }
    }
}
