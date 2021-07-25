using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class UserSkill : IEntity
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
