using Microsoft.Extensions.Logging;
using TCC.Domain.Entities;
using TCC.Domain.Gateways;
using TCC.Infra.DataProviders.Repositories.Abstract;

namespace TCC.Infra.DataProviders.Repositories
{
    public class ClientesRepository : BaseRepository<Cliente>, IClienteGateway
    {
        public ClientesRepository(DataContext context, ILogger<BaseRepository<Cliente>> logger) : base(context, logger)
        {
        }
    }
}
