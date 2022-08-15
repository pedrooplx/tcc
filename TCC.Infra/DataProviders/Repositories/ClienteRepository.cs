using Microsoft.Extensions.Logging;
using TCC.Domain.Entities;
using TCC.Domain.Gateways;
using TCC.Infra.DataProviders.Repositories.Abstract;

namespace TCC.Infra.DataProviders.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteGateway
    {
        public ClienteRepository(DataContext context, ILogger<BaseRepository<Cliente>> logger) : base(context, logger)
        {
        }
    }
}
