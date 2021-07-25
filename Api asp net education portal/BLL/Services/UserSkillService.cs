using AutoMapper;
using BLL.DtoModels;
using BLL.Interfaces;
using DAL.DBExt;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Services
{
    public class UserSkillService : IUserSkillService
    {
        private readonly IRepository repository;
        private readonly IMapper _mapper;
        //private readonly IUserService _userService;
        //private readonly UserManager<User> userManager;

        public UserSkillService(IRepository repo/*, IUserService userService*/)
        {
            this.repository = repo;
            //this._userService = userService;
            var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile(new MapperProfile()));
            _mapper = new Mapper(mapperConfiguration);
        }
        public void AddUserSkill(UserSkillModel model)
        {
            var skill = this.repository.FirstorDefault<Skill>(x => x.Id == model.SkillId);
            var user = repository.FirstorDefault<User>(x => x.Id == model.UserId);
            UserSkill userSkill = new UserSkill()
            {
                SkillId = skill.Id,
                Skill = skill,
                Level = model.Level,
                User = user,
                UserId = user.Id
            };
            this.repository.AddAndSave<UserSkill>(userSkill);
        }

        public IEnumerable<UserSkillModel> GetUserSkills(Expression<Func<UserSkill, bool>> predicate)
        {
            var listUserSkill = this.repository.GetWithInclude<UserSkill>(predicate, p => p.User, x => x.Skill);
            var listmodel = new List<UserSkillModel>();
            foreach (var item in listUserSkill)
            {
                var model = new UserSkillModel();
                model.Id = item.Id;
                model.User = _mapper.Map<UserModel>(item.User);
                model.Skill = _mapper.Map<SkillModel>(item.Skill);
                model.UserId = Convert.ToInt32(item.UserId);
                model.SkillId = item.SkillId;
                model.Level = item.Level;
                listmodel.Add(model);
            }
            return listmodel;
        }


        public UserSkillModel GetUserSkill(Expression<Func<UserSkill, bool>> predicate)
        {
            return _mapper.Map<UserSkillModel>(this.repository.FirstorDefault(predicate));
        }

        public UserSkillModel GetUserSkillById(int id)
        {
            var entity = this.repository.FirstorDefault<UserSkill>(x => x.Id == id);
            var model = new UserSkillModel()
            {
                Id = entity.Id,
                Level = entity.Level,
                User = _mapper.Map<UserModel>(entity.User),
                Skill = _mapper.Map<SkillModel>(entity.Skill),
                UserId = Convert.ToInt32(entity.UserId),
                SkillId = entity.SkillId
            };
            return model;
        }

        public void RemoveUserSkill(int id)
        {
            var userSkill = this.repository.FirstorDefault<UserSkill>(x => x.Id == id);
            if (userSkill == null)
            {
                throw new NullReferenceException();
            }
            this.repository.RemoveAndSave(userSkill);
        }

        public void UpdateUserSkill(int id, UserSkillModel model)
        {
            var userSkill = this.repository.FirstorDefault<UserSkill>(x => x.Id == id);
            if (userSkill == null)
            {
                throw new NullReferenceException();
            }
            var user = repository.FirstorDefault<User>(x => x.Id == model.UserId);
            userSkill.Skill = this.repository.FirstorDefault<Skill>(x => x.Id == model.SkillId);
            userSkill.Level = model.Level;
            userSkill.UserId = model.UserId;
            userSkill.SkillId = model.SkillId;
            this.repository.UpdateAndSave(userSkill);
        }

    }
}
