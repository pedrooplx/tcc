using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TCC.Application.Models.Organizacao
{
    public class RemoverOrganizacaoRequest
    {
        [Required]
        public Guid Id { get; set; }

        public RemoverOrganizacaoRequest(Guid id)
        {
            Id = id;
        }
    }
}
