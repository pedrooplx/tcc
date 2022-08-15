using Microsoft.Extensions.Logging;
using TCC.Domain.Entities;
using TCC.Domain.Gateways;
using TCC.Infra.DataProviders.Repositories.Abstract;

namespace TCC.Infra.DataProviders.Repositories
{
    public class ColaboradorRepository : BaseRepository<Colaborador>, IColaboradorGateway
    {
        public ColaboradorRepository(DataContext context, ILogger<BaseRepository<Colaborador>> logger) : base(context, logger)
        {
        }
    }
}
