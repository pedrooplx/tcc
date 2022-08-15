using Microsoft.Extensions.Logging;
using TCC.Domain.Entities;
using TCC.Domain.Gateways;
using TCC.Infra.DataProviders.Repositories.Abstract;

namespace TCC.Infra.DataProviders.Repositories
{
    public class ClassificacaoRepository : BaseRepository<Classificacao>, IClassificacaoGateway
    {
        public ClassificacaoRepository(DataContext context, ILogger<BaseRepository<Classificacao>> logger) : base(context, logger)
        {
        }
    }
}
