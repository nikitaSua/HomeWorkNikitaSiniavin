using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskInCl_2
{
    static class SearchMethods
    {
        public static void FirstCustomer(List<Customer> customers)
        {
            var minDate = customers.Min(c => c.RegistrationDate);
            var firstUser = customers.Select(c=>c).Where(c=> c.RegistrationDate == minDate);

            foreach (var item in firstUser)
            {
                Console.WriteLine
                        ($"Id:  {item.Id}, Name: {item.Name}, RegDate: {item.RegistrationDate}, Ballance: {item.Balance}");
            }
        }
        public static void avarageBalance(List<Customer> customers)
        {
            var avarage = customers.Average(c => c.Balance);
            Console.WriteLine(avarage);
        }
        public static void searchById(List<Customer> customers, int searchId)
        {
            var sortById = customers.FirstOrDefault(c => c.Id == searchId);

            Console.WriteLine
                    ($"Id:  {sortById.Id}, Name: {sortById.Name}, RegDate: {sortById.RegistrationDate}, Ballance: {sortById.Balance}");
        }

        public static void SortByDateInRange(List<Customer> customers, DateTime startD, DateTime finishD)
        {
            bool flag = true;

            if (startD.CompareTo(finishD) == 1)
            {

                DateTime temp = startD;
                startD = finishD;
                finishD = temp;
                flag = false;
            }

            var sortByStartDates = customers.Select(c => c).Where(c => c.RegistrationDate >= startD);
            var sortByfinishDates = sortByStartDates.Select(c => c).Where(c => c.RegistrationDate <= finishD);
            var ordered = sortByfinishDates.OrderBy(c => c.RegistrationDate);

            if (flag == false)
            {
                ordered = sortByfinishDates.OrderByDescending(c => c.RegistrationDate);
            }

            if (ordered.Count() != 0)
            {
                foreach (var item in ordered)
                {
                    Console.WriteLine
                        ($"Id:  {item.Id}, Name: {item.Name}, RegDate: {item.RegistrationDate}, Ballance: {item.Balance}");
                }
            }
            else
            {
                Console.WriteLine("No results");
            }
        }


        public static void SortByDateInRangeV2(List<Customer> customers, DateTime startD, DateTime finishD)
        {
            var sorted = customers.Where(c => c.RegistrationDate >= startD && c.RegistrationDate <= finishD).ToList();
            if (sorted.Count==0)
            {
                Console.WriteLine("NO result");
            }
            else
            {
                foreach (var item in sorted)
                {
                    Console.WriteLine
                        ($"Id:  {item.Id}, Name: {item.Name}, RegDate: {item.RegistrationDate}, Ballance: {item.Balance}");
                }
                
            }
        }

        public static void SearchByName(List<Customer> customers, string namePart)
        {
            var sorted = customers.Select(c => c).Where(c => c.Name.ToUpper().StartsWith(namePart.ToUpper()));
            foreach (var item in sorted)
            {
                Console.WriteLine
                    ($"Id:  {item.Id}, Name: {item.Name}, RegDate: {item.RegistrationDate}, Ballance: {item.Balance}");
            }
        }


        public static void SortByDateRegMonth(List<Customer> customers)
        {

            var sorted = customers.OrderBy(c => c.RegistrationDate.Month)
                .ThenBy(c => c.Name)
                .ThenBy(c => c.RegistrationDate.Month);
            foreach (var item in sorted)
            {
                Console.WriteLine
                    ($"Id:  {item.Id}, Name: {item.Name}, RegDate: {item.RegistrationDate}, Ballance: {item.Balance}");
            }
        }

        public static void SortFieldAndDirection<T>(List<Customer> customers, string property, bool direct)
        {

            var type = typeof(T);
            var sortProperty = type.GetProperty(property);
            var sorted= customers.OrderBy(p => sortProperty.GetValue(p, null)).ToList();

            if (direct ==false)
            {
                sorted = customers.OrderByDescending(p => sortProperty.GetValue(p, null)).ToList();
            }


            foreach (var item in sorted)
            {
                Console.WriteLine
                    ($"Id:  {item.Id}, Name: {item.Name}, RegDate: {item.RegistrationDate}, Ballance: {item.Balance}");
            }
        }

        public static void AllNameWriter(List<Customer> customers)
        {


            var sorted = string.Join(',', customers.Select(x => x.Name));
            Console.WriteLine(sorted);
        }



    }
}
