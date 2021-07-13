using Asp.Net.Practice_Forms.Models;
using Asp.Net.Practice_Forms.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Asp.Net.Practice_Forms.Services
{
    public class UserService
    {
        private readonly IRepository repository;
        public UserService(IRepository repos)
        {
            this.repository = repos;
        }

        public IEnumerable<User> GetUsers(Expression<Func<User, bool>> predicate)
        {
            var listOfUsers = this.repository.GetFilteredByQuery<User>(predicate);
            return listOfUsers;
        }
        public User GetUser(Expression<Func<User, bool>> predicate)
        {
            var user = this.repository.FirstorDefult(predicate);
            return user;
        }
        public void AddUser(User model)
        {
            this.repository.AddAndSave<User>(model);
        }
    }
}
