using CaseStudy.Core.Entities.Base;
using CaseStudy.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Infrastructure.Repository.Abstract
{
    public class BaseRepository<T, TContext> : IRepository<T>
        where T : BaseEntity, new()
        where TContext : DbContext
    {
        private readonly DbContext _context;

        protected BaseRepository(DbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Create(T entity, CancellationToken cancellationToken = default)
        {
            var result = await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public virtual async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var isDeleted = false;
            var entity = await GetById(id, cancellationToken);
            if (entity != null)
            {
                var deletedEntity = _context.Remove(entity);
                deletedEntity.State = EntityState.Deleted;
                isDeleted = await _context.SaveChangesAsync() >= 0;
            }
            return isDeleted;
        }

        public virtual async Task<IEnumerable<T>> Get(System.Linq.Expressions.Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> Update(T entity, CancellationToken cancellationToken)
        {
            var entityToUpdate = await GetById(entity.Id);
            _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
