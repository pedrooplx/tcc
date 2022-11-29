using System.Collections.Generic;

namespace TCC.Application.Models.Classificacao
{
    public class ObterClassificacoesResponse
    {
        public IEnumerable<ObterClassificacaoResponse> Classificacoes { get; set; }
    }
}
