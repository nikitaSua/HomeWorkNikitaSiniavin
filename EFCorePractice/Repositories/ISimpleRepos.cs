using EfPractice.Date.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePractice.Repositories
{
    public interface ISimpleRepos<TEntity>
        where TEntity :IEntity
    {
    }
}
