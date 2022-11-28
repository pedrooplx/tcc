using System.Collections.Generic;

namespace TCC.Application.Models.Classificacao
{
    public class ObterClassificacoesPorColaboradorResponse
    {
        public IEnumerable<ObterClassificacaoResponse> Classificacoes { get; set; }
    }
}
