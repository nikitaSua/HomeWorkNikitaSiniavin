using System;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace SaveDataCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите поля Person");
            string[] Propstr = Console.ReadLine().Split(',');
            var csv = new StringBuilder();
            foreach (var item in PersonList.GetListPerson())
            {
                PrintToFile(() => item.Name, Propstr, csv);
                PrintToFile(() => item.Address, Propstr, csv);
                PrintToFile(() => item.Age, Propstr, csv);
                PrintToFile(() => item.EyeColor, Propstr, csv);
                PrintToFile(() => item.Gender, Propstr, csv);
                PrintToFile(() => item.Salary, Propstr, csv);
                PrintToFile(() => item.Company, Propstr, csv);
                csv.Append("\n");
            }
            File.AppendAllText("E:\\file.csv", csv.ToString());

            static void PrintToFile<T>(Expression<Func <T>> expression , string[] propstr, StringBuilder csv)
            {
                foreach(var item in propstr)
                {
                    if (item == ((MemberExpression)expression.Body).Member.Name)
                    {
                        csv.Append(((MemberExpression)expression.Body).Member.Name + "  " + expression.Compile()());
                        csv.Append(", ");
                    }
                }
            }
        }
    }
}
