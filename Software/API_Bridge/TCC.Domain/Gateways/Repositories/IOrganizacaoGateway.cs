using System.Threading.Tasks;
using TCC.Domain.Entities;
using TCC.Domain.Gateways.Abstract;

namespace TCC.Domain.Gateways
{
    public interface IOrganizacaoGateway : IRepositoryGateway<Organizacao>
    {
        Task<Organizacao> ObterOrganizacaoPorCnpj(int cnpjOrganizacao);
    }
}
