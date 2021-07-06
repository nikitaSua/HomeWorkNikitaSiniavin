using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperPractice.Models
{
    public class Countries
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public List<Merchant> Merchants { get; set; }
        public Countries()
        {
            Users = new List<User>();
            Merchants = new List<Merchant>();
        }
    }
}
