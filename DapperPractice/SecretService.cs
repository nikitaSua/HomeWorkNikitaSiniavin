using DapperPractice.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperPractice
{
    public class SecretService
    {
        private readonly IRepository repository;

        public SecretService(IRepository repository)
        {
            this.repository = repository;
        }
        public void AddUser()
        {
            User user = new User();
            user.FullName = "testFullName";
            user.Email = "myEmail123@nix.com";
            user.Gender = '1';
            user.DateOfBirth = DateTime.Now;
            user.Country = 1;
            user.CreatedAt= DateTime.Now;
        }
        public IEnumerable<User> GetUsers()
        {
            return this.repository.GetAllAsync<User>().Result;
        }
        public IEnumerable<Merchant> GetMerchants()
        {
            return this.repository.GetAllAsync<Merchant>().Result;
        }
        public IEnumerable<Order> GetOrders()
        {
            return this.repository.GetAllAsync<Order>().Result;
        }

        public void HideUser(string email)
        {

            var user = this.repository.GetAllAsync<User>().Result.FirstOrDefault(x => x.Email == email);
            if (user != default)
            {
                var merchant = this.repository.GetAllAsync<Merchant>().Result.FirstOrDefault(m=>m.UserId==user.Id);
                var orders = this.repository.GetAllAsync<Order>().Result.Where(x => x.UserId == user.Id);
                if (merchant != default)
                {
                    merchant.Name = "Secret";
                    this.repository.UpdateAsync<Merchant>(merchant);
                }
                else
                {
                    Console.WriteLine("user is not Merchant");
                }
                user.FullName = "Secret";
                this.repository.UpdateAsync<User>(user);
                foreach (var order in orders)
                {
                    var AllUserOrderItems = this.repository.GetAllAsync<OrderItem>().Result.Where(x => x.Id == order.Id);
                    var products = this.repository.GetAllAsync<Product>().Result;
                    var ProdIdInOrder = AllUserOrderItems.Cast<OrderItem>().ToList().Select(x => x.ProductId);
                    var prodInOrder = products.Cast<Product>().ToList().Select(p => p).Where(x => ProdIdInOrder.Contains(x.Id));
                    order.OrderJson = JsonConvert.SerializeObject(new JsonSenderObj(user, (List<Product>)prodInOrder));
                    this.repository.UpdateAsync<Order>(order);
                }
            }
            else
            {
                Console.WriteLine($"User with this Email({email}) does not exist");
            }
        }
    }

}
