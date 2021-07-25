using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DtoModels
{
    public class MaterialSkillModel
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int? MaterialId { get; set; }
        public MaterialModel Material { get; set; }
        public int? SkillId { get; set; }
        public SkillModel Skill { get; set; }
    }
}
