using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCC.Domain.Entities.Abstract;
using TCC.Domain.Gateways.Abstract;
using TCC.Infra.DataProviders.Extensions;

namespace TCC.Infra.DataProviders.Repositories.Abstract
{
    public abstract class BaseRepository<TEntity> : IRepositoryGateway<TEntity> where TEntity : EntityBase, new()
    {
        private readonly DataContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private readonly ILogger<BaseRepository<TEntity>> _logger;

        protected BaseRepository(
            DataContext context,
            ILogger<BaseRepository<TEntity>> logger
        )
        {
            _context = context;
            _logger = logger;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            _logger.LogInformation($"Método GetByIdAsync invocado. Id:{id}. Entidade: {typeof(TEntity).FullName}");

            return await _dbSet.AsNoTracking().WhereIdEqual(x => x.Id, id).FirstOrDefaultAsync();

        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            _logger.LogInformation($"Método GetAllAsync invocado. Entidade: {typeof(TEntity).FullName}");

            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task InsertAsync(TEntity entity)
        {
            _logger.LogInformation($"Método InsertAsync invocado. Entidade: {typeof(TEntity).FullName}");

            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _logger.LogInformation($"Método UpdateAsync invocado. Entidade: {typeof(TEntity).FullName}");

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            _logger.LogInformation($"Método DeleteAsync invocado. Id:{id}. Entidade: {typeof(TEntity).FullName}");

            _dbSet.Remove(await _dbSet.WhereIdEqual(x => x.Id, id).FirstOrDefaultAsync());
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
