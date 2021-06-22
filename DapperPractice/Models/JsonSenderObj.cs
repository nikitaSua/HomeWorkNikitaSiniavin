using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperPractice.Models
{
    public class JsonSenderObj
    {
        public int OrderId { get; set; }
        public SimpledUser User { get; set; }
        public List<SimpledProd> Products { get; set; }
        public JsonSenderObj(User user, List<Product> products)
        {
            this.User = new SimpledUser(user);

            List<SimpledProd> sProd = new List<SimpledProd>();
            foreach (var item in products)
            {
                sProd.Add(new SimpledProd(item));
            }
            this.Products = sProd;

        }
    }
    public class SimpledUser
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public SimpledUser(User user)
        {
            this.FullName = user.FullName;
            this.Email = user.Email;
        }
    }
    public class SimpledProd
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public SimpledProd(Product prod)
        {
            this.Name = prod.Name;
            this.Price = Convert.ToString(prod.Price);
        }
    }
}
