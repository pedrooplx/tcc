using System.Collections.Generic;
using System.Threading.Tasks;
using TCC.Domain.Entities;
using TCC.Domain.Gateways.Abstract;

namespace TCC.Domain.Gateways
{
    public interface IClassificacaoGateway : IRepositoryGateway<Classificacao>
    {
        Task<IEnumerable<Classificacao>> ObterClassificacoesPorColaboradorAsync(long funcionalColaborador);
        Task<IEnumerable<Classificacao>> ObterClassificacoesPorOrganizacaoAsync(int cnpjOrganizacao);
    }
}