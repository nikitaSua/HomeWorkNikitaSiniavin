using SimpleInjector;
using System;

namespace DapperPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            container.Register<IRepository, DapperRepository>(Lifestyle.Singleton);
            container.Register<SecretService>();
            var service = container.GetInstance<SecretService>();
            container.Verify();
            Console.WriteLine("Enter Email");
            service.AddUser();
            string email = Console.ReadLine();
        }
    }
}
