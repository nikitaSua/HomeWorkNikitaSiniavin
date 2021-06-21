using EfPractice.Date.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePractice.Repositories
{
    public interface IRepository
    {
        TEntity FirstorDefault<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;

        IEnumerable<TEntity> GetFilteredByQuery<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;

        IEnumerable<TEntity> GetWithInclude<TEntity>(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class, IEntity;

        void AddAndSave<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void UpdateAndSave<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void RemoveAndSave<TEntity>(TEntity entity) where TEntity : class, IEntity;

        Task SaveAsync();
    }
}
