using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperPractice.Models
{
    public class Order:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get { return CreatedAt; } set { CreatedAt = DateTime.Now; } }
        public string OrderJson { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
