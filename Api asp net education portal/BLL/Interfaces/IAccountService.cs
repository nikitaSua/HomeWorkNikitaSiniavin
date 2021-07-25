using BLL.DtoModels;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        public User GetUser(Expression<Func<User, bool>> predicate);
        public Role GetRole(Expression<Func<Role, bool>> predicate);
        public User MapToUserFromRegModel(RegisterModel model);
        public void AddUser(UserModel model);
        public User GetUserWithRole(Expression<Func<User, bool>> predicate, LoginModel model);
    }
}
