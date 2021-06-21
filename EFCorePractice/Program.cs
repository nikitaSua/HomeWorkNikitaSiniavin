using BLL.Services;
using System;

namespace EFCorePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoriePermServ dirPermServ = new DirectoriePermServ();
            var a = dirPermServ.GetDirectoryFiles(x => true);
            
            foreach (var item in a)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("dasdas");
        }
    }
}
