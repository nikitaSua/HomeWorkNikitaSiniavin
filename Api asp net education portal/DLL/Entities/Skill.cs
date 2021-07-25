using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Skill : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MaterialSkill> MaterialSkills { get; set; }
        public List<UserSkill> UserSkills { get; set; }
        public Skill()
        {
            this.UserSkills = new List<UserSkill>();
            this.MaterialSkills = new List<MaterialSkill>();
        }
    }
}
