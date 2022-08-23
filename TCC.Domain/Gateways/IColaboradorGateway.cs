using System.Collections.Generic;
using System.Threading.Tasks;
using TCC.Domain.Entities;
using TCC.Domain.Gateways.Abstract;

namespace TCC.Domain.Gateways
{
    public interface IColaboradorGateway : IRepositoryGateway<Colaborador>
    {
        Task<Colaborador> ObterColaboradorComEmpresaPorIdAsync(long id);
        Task<IEnumerable<Colaborador>> ObterColaboradoresComEmpresaAsync();
    }
}