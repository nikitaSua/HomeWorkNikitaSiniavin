using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBExt
{
    public interface IRepository
    {
        TEntity FirstorDefault<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;

        IEnumerable<TEntity> GetFilteredByQuery<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;

        IEnumerable<TEntity> GetWithInclude<TEntity>(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class, IEntity;

        Task AddAndSave<TEntity>(TEntity entity) where TEntity : class, IEntity;

        Task  UpdateAndSave<TEntity>(TEntity entity) where TEntity : class, IEntity;

        Task RemoveAndSave<TEntity>(TEntity entity) where TEntity : class, IEntity;

        Task SaveAsync();
    }
}
