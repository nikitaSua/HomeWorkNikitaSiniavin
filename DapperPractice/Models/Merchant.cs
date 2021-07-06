using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperPractice.Models
{
    public class Merchant : IEntity
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryCode { get; set; }
        public Countries Countries { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public List<Product> Products { get; set; }
        public Merchant()
        {
            Products = new List<Product>();
        }
    }
}
