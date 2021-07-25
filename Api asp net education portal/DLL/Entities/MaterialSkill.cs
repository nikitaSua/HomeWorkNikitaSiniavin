using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class MaterialSkill:IEntity
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int? MaterialId { get; set; }
        public Material Material { get; set; }
        public int? SkillId { get; set; }
        public  Skill Skill { get; set; }
    }
}
