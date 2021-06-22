using DapperPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperPractice
{
    public interface IRepository 
    {
        Task<TEntity> GetAsync<TEntity>(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class, IEntity;
        Task DeleteRowAsync<TEntity>(Guid id);
        Task<int> SaveRangeAsync<TEntity>(IEnumerable<TEntity> list);
        Task UpdateAsync<TEntity>(TEntity t);
        Task InsertAsync<TEntity>(TEntity t);
    }
}
