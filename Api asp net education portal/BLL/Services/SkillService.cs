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
    public class SkillService : ISkillService 
    {
        private readonly IRepository repository;
        private readonly IMapper _mapper;
        public SkillService(IRepository serializer)
        {
            this.repository = serializer;
            var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile(new MapperProfile()));
            _mapper = new Mapper(mapperConfiguration);
        }
        public void AddSkill(SkillModel skillModel)
        {
            Skill skill = _mapper.Map<Skill>(skillModel);
            repository.AddAndSave(skill);
        }
        public IEnumerable<SkillModel> GetSkills(Expression<Func<Skill, bool>> predicate)
        {
            return _mapper.Map<List<SkillModel>>(this.repository.GetFilteredByQuery<Skill>(predicate));
        }
        public SkillModel GetSkill(Expression<Func<Skill, bool>> predicate)
        {
            return _mapper.Map<SkillModel>(this.repository.FirstorDefault(predicate));
        }

        public SkillModel GetSkillById(int id)
        {
            var entity = this.repository.FirstorDefault<Skill>(x => x.Id == id);
            var model = new SkillModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Description = entity.Description;
            return model;
        }

        public void RemoveSkill(int id)
        {
            var Skill = this.repository.FirstorDefault<Skill>(x => x.Id == id);
            if (Skill == null)
            {
                throw new NullReferenceException();
            }
            this.repository.RemoveAndSave(Skill);
        }

        public void UpdateSkill(int id, SkillModel model)
        {
            var skill = this.repository.FirstorDefault<Skill>(x => x.Id == id);
            if (skill == null)
            {
                throw new NullReferenceException();
            }
            skill.Id = model.Id;
            skill.Name = model.Name;
            skill.Description = model.Description;
            this.repository.UpdateAndSave(skill);
        }

    }
}
