using System;
using System.ComponentModel.DataAnnotations;
using TCC.Application.Models.Abstract;

namespace TCC.Application.Models.Organizacao
{
    public class ObterOrganizacaoPorIdRequest : BaseRequest
    {
        [Required]
        public long Id { get; set; }

        public ObterOrganizacaoPorIdRequest(long id)
        {
            Id = id;
        }
    }
}
