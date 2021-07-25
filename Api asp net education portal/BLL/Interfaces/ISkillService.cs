
using BLL.DtoModels;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Interfaces
{
    public interface ISkillService 
    {
        IEnumerable<SkillModel> GetSkills(Expression<Func<Skill, bool>> predicate);

        SkillModel GetSkillById(int id);

        SkillModel GetSkill(Expression<Func<Skill, bool>> predicate);
        

        void AddSkill(SkillModel model);

        void UpdateSkill(int id, SkillModel model);

        void RemoveSkill(int id);
    }
}
