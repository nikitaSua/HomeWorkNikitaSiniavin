using Asp.Net.Practice_Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Asp.Net.Practice_Forms.Repositorys
{
    public interface IRepository
    {
        TEntity FirstorDefult<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;
        IEnumerable<TEntity> GetFilteredByQuery<TEntity> (Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;
        void AddAndSave<TEntity>(TEntity entity) where TEntity : class, IEntity;
        void RemoveAndSave<TEntity>(TEntity entity) where TEntity : class, IEntity;
        Task SaveAsync();
    }
}
