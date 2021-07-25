using AutoMapper;
using BLL.DtoModels;
using BLL.Interfaces;
using DAL.DBExt;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AccountService:IAccountService
    {
        private readonly IRepository repository;
        private readonly IMapper _mapper;

        public AccountService(IRepository repo)
        {
            this.repository = repo;
            var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile(new MapperProfile()));
            _mapper = new Mapper(mapperConfiguration);
        }
        public User GetUser(Expression<Func<User, bool>> predicate)
        {
            var user = this.repository.FirstorDefault(predicate);
            return user;
        }
        public Role GetRole(Expression<Func<Role, bool>> predicate)
        {
            var role = this.repository.FirstorDefault(predicate);
            return role;
        }
        public User MapToUserFromRegModel(RegisterModel model)
        {
            return _mapper.Map<User>(model);
        }
        public void AddUser(UserModel model)
        {

            var user = _mapper.Map<User>(model);
            user.RoleId = 1;// устанавливаем роль пользователя в USER
            this.repository.AddAndSave<User>(user);
        }

        public User GetUserWithRole(Expression<Func<User, bool>> predicate, LoginModel model)
        {
            var users = this.repository.GetWithInclude(predicate, r => r.Role);
            User result = users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            return result;
        }

    }
}
