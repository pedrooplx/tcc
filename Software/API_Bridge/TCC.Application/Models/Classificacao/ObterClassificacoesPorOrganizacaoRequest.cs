using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TCC.Application.Models.Classificacao
{
    public class ObterClassificacoesPorOrganizacaoRequest
    {
        [Required]
        public int CnpjOrganizacao { get; set; }

        public ObterClassificacoesPorOrganizacaoRequest(int cnpj)
        {
            CnpjOrganizacao = cnpj;
        }
    }
}
