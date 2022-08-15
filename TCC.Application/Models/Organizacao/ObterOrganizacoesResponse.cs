using System.Collections.Generic;

namespace TCC.Application.Models.Organizacao
{
    public class ObterOrganizacoesResponse
    {
        public IEnumerable<ObterOrganizacaoPorIdResponse> Organizacoes { get; set; }
    }
}
