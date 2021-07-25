using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DtoModels
{
    public class CourseMaterialModel
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public CourseModel Course { get; set; }
        public int? MaterialId { get; set; }
        public MaterialModel Material { get; set; }
    }
}
