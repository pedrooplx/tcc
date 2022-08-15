using System;
using System.ComponentModel.DataAnnotations;

namespace TCC.Application.Models.Organizacao
{
    public class ObterOrganizacaoPorIdRequest
    {
        [Required]
        public Guid Id { get; set; }

        public ObterOrganizacaoPorIdRequest(Guid id)
        {
            Id = id;
        }
    }
}
