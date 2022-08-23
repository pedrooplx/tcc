using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCC.Domain.Entities;
using TCC.Domain.Gateways;
using TCC.Infra.DataProviders.Repositories.Abstract;

namespace TCC.Infra.DataProviders.Repositories
{
    public class ColaboradorRepository : BaseRepository<Colaborador>, IColaboradorGateway
    {
        private readonly DataContext _context;
        public ColaboradorRepository(DataContext context, ILogger<BaseRepository<Colaborador>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<Colaborador> ObterColaboradorComEmpresaPorIdAsync(long id)
        {
            return await _context.Colaboradores.AsNoTracking()
                .Include(c => c.Organizacao)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Colaborador>> ObterColaboradoresComEmpresaAsync()
        {
            return await _context.Colaboradores.AsNoTracking()
                .Include(c => c.Organizacao)
                .ToListAsync();
        }
    }
}
