using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperPractice.Models
{
    public class Product: IEntity
    {
        public int Id { get; set; }
        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; }
        public string Name  { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get { return CreatedAt; } set { CreatedAt = DateTime.Now; } }
        public List<OrderItem> OrderItems { get; set; }
        public Product()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
