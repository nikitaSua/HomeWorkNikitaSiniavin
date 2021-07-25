using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    [Serializable]
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<CourseUser> CourseUser { get; set; }
        public List<UserSkill> UserSkill { get; set; }
        public User()
        {
            this.CourseUser = new List<CourseUser>();
            this.UserSkill = new List<UserSkill>();
        }
    }
}
