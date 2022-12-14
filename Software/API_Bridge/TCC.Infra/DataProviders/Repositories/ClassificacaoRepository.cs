using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.Domain.Entities;
using TCC.Domain.Gateways;
using TCC.Infra.DataProviders.Repositories.Abstract;

namespace TCC.Infra.DataProviders.Repositories
{
    public class ClassificacaoRepository : BaseRepository<Classificacao>, IClassificacaoGateway
    {
        private readonly DataContext _context;

        public ClassificacaoRepository(DataContext context, ILogger<BaseRepository<Classificacao>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<IEnumerable<Classificacao>> ObterClassificacoesPorColaboradorAsync(long idColaborador)
        {
            return await _context.Classificacoes.AsNoTracking()
               .Include(c => c.Colaborador)
               .Where(c => c.ColaboradorId == idColaborador)
               .OrderByDescending(c => c.CriandoEm)
               .ToListAsync();
        }

        public async Task<IEnumerable<Classificacao>> ObterClassificacoesPorOrganizacaoAsync(int cnpjOrganizacao)
        {
            return await _context.Classificacoes.AsNoTracking()
               .Include(c => c.Colaborador)
               .Where(c => c.Colaborador.Organizacao.Cnpj == cnpjOrganizacao)
               .OrderByDescending(c => c.CriandoEm)
               .ToListAsync();
        }
    }
}
