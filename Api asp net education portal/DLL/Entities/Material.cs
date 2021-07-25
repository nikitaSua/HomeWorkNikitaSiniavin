using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Material:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MaterialSkill> MaterialSkills { get; set; }
        public List<CourseMaterial> CourseMaterials { get; set; }
        public Material()
        {
            this.MaterialSkills = new List<MaterialSkill>();
            this.CourseMaterials = new List<CourseMaterial>();
        }
    }
}
