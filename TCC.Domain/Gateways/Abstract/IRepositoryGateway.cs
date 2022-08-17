using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCC.Domain.Entities.Abstract;

namespace TCC.Domain.Gateways.Abstract
{
    public interface IRepositoryGateway<TEntity> : IDisposable where TEntity : EntityBase
    {
        Task<TEntity> GetByIdAsync(long id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity entity);
        Task InsertAsync(TEntity entity);
        Task DeleteAsync(long id);
    }
}