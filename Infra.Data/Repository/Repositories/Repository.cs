using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Business.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository.Repositories
{
    public class Repository<TDbContext, TEntity> : IRepository<TEntity>
    where TEntity : class
    where TDbContext : DbContext
    {

        protected readonly TDbContext _context;
        protected readonly DbSet<TEntity> _entity;
        public Repository(TDbContext context)
        {
            _context = context;
            _entity = context.Set<TEntity>();
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _entity.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> CreateManyAsync(List<TEntity> entities)
        {
            await _entity.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            _entity.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task<List<TEntity>> DeleteManyAsync(List<TEntity> entities)
        {
            _entity.RemoveRange(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        public async Task<bool> Exists(Expression<Func<TEntity, bool>> expressionSearch)
        {
            var result = await _entity.AnyAsync(expressionSearch);
            await _context.SaveChangesAsync();
            return result;
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expressionSearch)
        {
            var result = _entity.Where(expressionSearch).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> expressionSearch)
        {
            var results = await _entity.Where(expressionSearch).ToListAsync();
            return results;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _entity.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}