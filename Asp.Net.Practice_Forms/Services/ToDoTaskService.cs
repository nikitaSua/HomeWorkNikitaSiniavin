using Asp.Net.Practice_Forms.Models;
using Asp.Net.Practice_Forms.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Asp.Net.Practice_Forms.Services
{
    public class ToDoTaskService
    {
        private readonly IRepository repository;
        public ToDoTaskService(IRepository repos)
        {
            this.repository = repos;
        }
        public IEnumerable<ToDoTask> GetUsers(Expression<Func<ToDoTask, bool>> predicate)
        {
            var listOfUsers = this.repository.GetFilteredByQuery<ToDoTask>(predicate);
            return listOfUsers;
        }
    }
    
    
}
