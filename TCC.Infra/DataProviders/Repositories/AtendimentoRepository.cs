using Microsoft.Extensions.Logging;
using TCC.Domain.Entities;
using TCC.Domain.Gateways;
using TCC.Infra.DataProviders.Repositories.Abstract;

namespace TCC.Infra.DataProviders.Repositories
{
    public class AtendimentoRepository : BaseRepository<Atendimento>, IAtendimentoGateway
    {
        public AtendimentoRepository(DataContext context, ILogger<BaseRepository<Atendimento>> logger) : base(context, logger)
        {
        }
    }
}
