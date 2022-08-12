using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCC.Domain.Abstract;

namespace TCC.Domain.Gateways.Abstract
{
    public interface IRepositoryGateway<TEntity> : IDisposable where TEntity : EntityBase
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity entity);
        Task InsertAsync(TEntity entity);
        Task DeleteAsync(Guid id);
    }
}