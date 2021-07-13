using Asp.Net.Practice_Forms.Data;
using Asp.Net.Practice_Forms.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Asp.Net.Practice_Forms.Repositorys
{
    
    public class EfRepos : IRepository
    {
        private DbContext context;

        public EfRepos(MvcDBContext dbContext)
        {
            this.context = dbContext;
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        void IRepository.AddAndSave<TEntity>(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
            this.context.SaveChanges();
        }

        TEntity IRepository.FirstorDefult<TEntity>(Expression<Func<TEntity, bool>> predicate)
        {
            return this.context.Set<TEntity>().FirstOrDefault(predicate);
        }

        IEnumerable<TEntity> IRepository.GetFilteredByQuery<TEntity>(Expression<Func<TEntity, bool>> predicate)
        {
            return this.context.Set<TEntity>().Where<TEntity>(predicate);
        }
        void IRepository.RemoveAndSave<TEntity>(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
            this.context.SaveChanges();
        }
    }
}
