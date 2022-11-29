using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TCC.Domain.Entities;
using TCC.Domain.Gateways;
using TCC.Infra.DataProviders.Repositories.Abstract;

namespace TCC.Infra.DataProviders.Repositories
{
    public class OrganizacaoRepository : BaseRepository<Organizacao>, IOrganizacaoGateway
    {
        private readonly DataContext _context;
        public OrganizacaoRepository(DataContext context, ILogger<BaseRepository<Organizacao>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<Organizacao> ObterOrganizacaoPorCnpj(int cnpjOrganizacao)
        {
            return await _context.Organizacoes.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Cnpj == cnpjOrganizacao);
        }
    }
}
