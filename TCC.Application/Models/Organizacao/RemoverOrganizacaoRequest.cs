using System;
using System.ComponentModel.DataAnnotations;
using TCC.Application.Models.Abstract;

namespace TCC.Application.Models.Organizacao
{
    public class RemoverOrganizacaoRequest : BaseRequest
    {
        [Required]
        public Guid Id { get; set; }

        public RemoverOrganizacaoRequest(Guid id)
        {
            Id = id;
        }
    }
}
