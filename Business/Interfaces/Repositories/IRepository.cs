using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expressionSearch);
        Task<bool> Exists(Expression<Func<TEntity, bool>> expressionSearch);
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> expressionSearch);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> CreateManyAsync(List<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<List<TEntity>> DeleteManyAsync(List<TEntity> entities);
    }
}