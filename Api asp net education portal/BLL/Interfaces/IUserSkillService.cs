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
    public interface IUserSkillService
    {
        IEnumerable<UserSkillModel> GetUserSkills(Expression<Func<UserSkill, bool>> predicate);

        UserSkillModel GetUserSkillById(int id);

        UserSkillModel GetUserSkill(Expression<Func<UserSkill, bool>> predicate);

        void AddUserSkill(UserSkillModel model);

        void UpdateUserSkill(int id, UserSkillModel model);

        void RemoveUserSkill(int id);
    }
}
