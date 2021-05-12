using System;
using System.Collections.Generic;

namespace TaskInCl_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var customers = new List<Customer>
                {
                    new Customer(1, "Tawana Shope", new DateTime(2017, 7, 15), 15.8),
                    new Customer(2, "Danny Wemple", new DateTime(2016, 2, 3), 88.54),
                    new Customer(3, "Margert Journey", new DateTime(2017, 11, 19), 0.5),
                    new Customer(4, "Tyler Gonzalez", new DateTime(2017, 5, 14), 184.65),
                    new Customer(5, "Melissa Demaio", new DateTime(2016, 9, 24), 241.33),
                    new Customer(6, "Cornelius Clemens", new DateTime(2016, 4, 2), 99.4),
                    new Customer(7, "Silvia Stefano", new DateTime(2017, 7, 15), 40),
                    new Customer(8, "Margrett Yocum", new DateTime(2017, 12, 7), 62.2),
                    new Customer(9, "Clifford Schauer", new DateTime(2017, 6, 29), 89.47),
                    new Customer(10, "Norris Ringdahl", new DateTime(2017, 1, 30), 13.22),
                    new Customer(11, "Delora Brownfield", new DateTime(2011, 10, 11), 0),
                    new Customer(12, "Sparkle Vanzile", new DateTime(2017, 7, 15), 12.76),
                    new Customer(13, "Lucina Engh", new DateTime(2017, 3, 8), 19.7),
                    new Customer(14, "Myrna Suther", new DateTime(2017, 8, 31), 13.9),
                    new Customer(15, "Fidel Querry", new DateTime(2016, 5, 17), 77.88),
                    new Customer(16, "Adelle Elfrink", new DateTime(2017, 11, 6), 183.16),
                    new Customer(17, "Valentine Liverman", new DateTime(2017, 1, 18), 13.6),
                    new Customer(18, "Ivory Castile", new DateTime(2016, 4, 21), 36.8),
                    new Customer(19, "Florencio Messenger", new DateTime(2017, 10, 2), 36.8),
                    new Customer(20, "Anna Ledesma", new DateTime(2017, 12, 29), 0.8)
                };

            //SearchMethods.FirstCustomer(customers);

            //Console.WriteLine(SearchMethods.avarageBalance(customers));

            //SearchMethods.SortByDateInRange(customers, new DateTime(2011, 7, 10), new DateTime(2017, 10, 2));
            //SearchMethods.SortByDateInRangeV2(customers, new DateTime(2017, 10, 2), new DateTime(2011, 7, 10));

            //SearchMethods.SearchByName(customers, "Margert");
            //SearchMethods.SortFieldAndDirection<Customer>(customers, "Name");

            SearchMethods.AllNameWriter(customers);

            do
            {
                Console.Clear();
                Console.WriteLine("Enter number of task");
                Console.WriteLine("1 -FirstCustomer  A");
                Console.WriteLine("2 -avarageBalance  B");
                Console.WriteLine("3 -SortByDateInRange  C");
                Console.WriteLine("4 -searchById  D");
                Console.WriteLine("5 -SearchByName  E");
                Console.WriteLine("6 -SortByDateRegMonth  F");
                Console.WriteLine("7 -SortFieldAndDirection  G");
                Console.WriteLine("8 -SortFieldAndDirection  H");

                int num = Convert.ToInt32(Console.ReadLine());

                switch (num)
                {
                    case 1:
                        SearchMethods.FirstCustomer(customers);
                        Console.ReadLine();
                        break;
                    case 2:
                        SearchMethods.avarageBalance(customers);
                        Console.ReadLine();
                        break;
                    case 3:
                        SearchMethods.SortByDateInRange(customers, new DateTime(2017, 1, 1), new DateTime(2017, 10, 2));
                        Console.ReadLine();
                        break;
                    case 4:
                        SearchMethods.searchById(customers,5);
                        Console.ReadLine();
                        break;
                    case 5:
                        SearchMethods.SearchByName(customers, "Fidel");
                        Console.ReadLine();
                        break;
                    case 6:
                        SearchMethods.SortByDateRegMonth(customers);
                        Console.ReadLine();
                        break;
                    case 7:
                        SearchMethods.SortFieldAndDirection<Customer>(customers, "Name", true);
                        Console.ReadLine();
                        break;
                    case 8:
                        SearchMethods.AllNameWriter(customers);
                        Console.ReadLine();
                        break;

                    default:
                        break;
                }


            } while (true);









        }
    }
}
