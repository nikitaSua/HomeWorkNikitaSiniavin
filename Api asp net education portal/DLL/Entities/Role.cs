using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public Role()
        {
            this.Users = new List<User>();
        }
    }
}
