using System;
using System.ComponentModel.DataAnnotations;
using TCC.Application.Models.Abstract;

namespace TCC.Application.Models.Clientes
{
    public class ObterClientePorIdRequest : BaseRequest
    {
        [Required]
        public long Id { get; set; }

        public ObterClientePorIdRequest(long id)
        {
            Id = id;
        }
    }
}
