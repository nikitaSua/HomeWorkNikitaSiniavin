using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperPractice.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Country { get; set; }
        public DateTime CreatedAt { get { return CreatedAt; } set { CreatedAt = DateTime.Now; } }
        public List<Merchant> Merchants { get; set; }
        public List<Order> Orders { get; set; }
        public User()
        {
            Orders = new List<Order>();
            Merchants = new List<Merchant>();
        }

    }
}
