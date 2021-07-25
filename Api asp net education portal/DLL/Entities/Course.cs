using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Course:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CourseMaterial> CourseMaterials { get; set; }
        public List<CourseUser> CourseUsers { get; set; }
        public Course()
        {
            this.CourseMaterials = new List<CourseMaterial>();
            this.CourseUsers = new List<CourseUser>();
        }
    }
}
