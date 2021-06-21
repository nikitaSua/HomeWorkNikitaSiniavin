using EFCorePractice.Extention;
using EFCorePractice.Models;
using EFCorePractice.Specification;
using EfPractice.Date.Core.Contexts;
using EfPractice.Date.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EFCorePractice.Repositories
{
    public class EfSimpleDirectorieRepos<TEntity> : ISimpleRepos<TEntity> 
        where TEntity : class,IEntity
    {
        private DbContext context;
        protected readonly DbSet<TEntity> entities;

        public EfSimpleDirectorieRepos(FileSystemConext dbContext)
        {
            this.context = dbContext;
        }
        public virtual Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return this.entities.AddAsync(entity, cancellationToken).AsTask();
        }

        public virtual Task AddAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return this.entities.AddRangeAsync(entities, cancellationToken);
        }

        public virtual Task<TEntity> FindAsync(int id, CancellationToken cancellationToken = default)
        {
            return this.entities.FirstOrDefaultAsync(x => x.Id== id, cancellationToken);
        }
        public virtual async Task<IEnumerable<TEntity>> GetAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return await this.entities.Where(specification.Expression).ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public virtual Task<PagedList<TEntity>> GetAsync(Specification<TEntity> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            return this.entities.Where(specification.Expression).ToPagedListAsync(pageNumber, pageSize, cancellationToken);
        }

        public virtual Task RemoveAsync(TEntity entities, CancellationToken cancellationToken = default)
        {
            this.entities.Remove(entities);
            return Task.CompletedTask;
        }

        public virtual Task RemoveAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            this.entities.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public virtual Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            this.entities.Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task UpdateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            this.entities.UpdateRange(entities);
            return Task.CompletedTask;
        }
    }
}
