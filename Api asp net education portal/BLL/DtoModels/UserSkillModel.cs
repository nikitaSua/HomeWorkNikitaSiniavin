using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DtoModels
{
    public class UserSkillModel
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int UserId { get; set; }
        public virtual UserModel User { get; set; }
        public int? SkillId { get; set; }
        public virtual SkillModel Skill { get; set; }
    }
}
