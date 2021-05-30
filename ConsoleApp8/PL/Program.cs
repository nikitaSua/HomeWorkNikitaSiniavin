using BLL.Abstractions.Interfaces;
using Core.Models;
using IoCResolver;
using SimpleInjector;
using System;
using System.Collections.Generic;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            DIRegistration.Load(container);
            var service = container.GetInstance<IUserService>();
            var users = service.LoadRecords();
            for (int i = 0; i < users.Count; i++)
            {
                List<User> result = users.FindAll(delegate (User user) {
                    return user.LastName == users[i].LastName;
                });
                foreach (var item in result)
                {
                    Console.WriteLine($"Matching Record, got name={item.FirstName}, lastname={item.LastName}, age={item.Age}");
                }
            }
            Console.ReadKey();
        }
    }
}
