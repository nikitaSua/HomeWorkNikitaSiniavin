using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DtoModels
{
    public class CourseUserModel
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public CourseModel Course { get; set; }
        public int? UserId { get; set; }
        public UserModel User { get; set; }
    }
}
