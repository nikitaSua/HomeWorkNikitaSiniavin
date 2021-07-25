
using BLL.DtoModels;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Interfaces
{
    public interface IMaterialSkillService 
    {
        IEnumerable<MaterialSkillModel> GetMaterialSkills(Expression<Func<MaterialSkill, bool>> predicate);

        MaterialSkillModel GetMaterialSkillById(int id);

        MaterialSkillModel GetMaterialSkill(Expression<Func<MaterialSkill, bool>> predicate);

        void AddMaterialSkill(MaterialSkillModel model);

        void UpdateMaterialSkill(int id, MaterialSkillModel model);

        void RemoveMaterialSkill(int id);
    }
}
