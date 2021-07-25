using AutoMapper;
using BLL.DtoModels;
using BLL.Interfaces;
using DAL.DBExt;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Services
{
    public class MaterialSkillService : IMaterialSkillService
    {
        private readonly IRepository repository;
        private readonly IMapper _mapper;

        public MaterialSkillService(IRepository repo)
        {
            this.repository = repo;
            var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile(new MapperProfile()));
            _mapper = new Mapper(mapperConfiguration);
        }
        public void AddMaterialSkill(MaterialSkillModel model)
        {
            var skill = this.repository.FirstorDefault<Skill>(x => x.Id == model.SkillId);
            var material = this.repository.FirstorDefault<Material>(x => x.Id == model.MaterialId);
            MaterialSkill materialSkill = new MaterialSkill()
            {
                Skill = skill,
                Material = material,
                SkillId = skill.Id,
                MaterialId = material.Id,
                Level = model.Level
            };
            this.repository.AddAndSave<MaterialSkill>(materialSkill);
        }

        public IEnumerable<MaterialSkillModel> GetMaterialSkills(Expression<Func<MaterialSkill, bool>> predicate)
        {
            var listMaterialSkill = this.repository.GetWithInclude(predicate, p => p.Material, x=> x.Skill);
            var listmodel = new List<MaterialSkillModel>();
            foreach (var item in listMaterialSkill)
            {
                var model = new MaterialSkillModel();
                model.Id = item.Id;
                model.MaterialId = item.MaterialId;
                model.Material = _mapper.Map<MaterialModel>(item.Material);
                model.Skill = _mapper.Map<SkillModel>(item.Skill);
                model.SkillId = item.SkillId;
                model.Level = item.Level;
                listmodel.Add(model);
            }
            return listmodel;
        }


        public MaterialSkillModel GetMaterialSkill(Expression<Func<MaterialSkill, bool>> predicate)
        {
            return _mapper.Map<MaterialSkillModel>(this.repository.FirstorDefault(predicate));
        }

        public MaterialSkillModel GetMaterialSkillById(int id)
        {
            var entity = this.repository.FirstorDefault<MaterialSkill>(x => x.Id == id);
            var model = new MaterialSkillModel();
            model.Id = entity.Id;
            model.Level = entity.Level;
            model.MaterialId = entity.MaterialId;
            model.SkillId = entity.SkillId;
            return model;
        }

        public void RemoveMaterialSkill(int id)
        {
            var materialSkill = this.repository.FirstorDefault<MaterialSkill>(x => x.Id == id);
            if (materialSkill == null)
            {
                throw new NullReferenceException();
            }   
            this.repository.RemoveAndSave(materialSkill);
        }

        public void UpdateMaterialSkill(int id, MaterialSkillModel model)
        {
            var materialSkill = this.repository.FirstorDefault<MaterialSkill>(x => x.Id == id);
            if (materialSkill == null)
            {
                throw new NullReferenceException();
            }  
            materialSkill.MaterialId = model.MaterialId;
            materialSkill.Level = model.Level;
            materialSkill.Material = _mapper.Map<Material>(model.Material);
            materialSkill.Skill = _mapper.Map<Skill>(model.Skill);
            materialSkill.SkillId = model.SkillId;
            this.repository.UpdateAndSave(materialSkill);
        }

    }
}
