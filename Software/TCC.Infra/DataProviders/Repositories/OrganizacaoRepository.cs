using Microsoft.Extensions.Logging;
using TCC.Domain.Entities;
using TCC.Domain.Gateways;
using TCC.Infra.DataProviders.Repositories.Abstract;

namespace TCC.Infra.DataProviders.Repositories
{
    public class OrganizacaoRepository : BaseRepository<Organizacao>, IOrganizacaoGateway
    {
        public OrganizacaoRepository(DataContext context, ILogger<BaseRepository<Organizacao>> logger) : base(context, logger)
        {
        }
    }
}
