using System;
using System.IO;

namespace SaveDataCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите поля Person");
            string answer = Console.ReadLine();
            string[] words = answer.Split(',');
            string result = "";
            foreach (var person in PersonList.GetListPerson())
            {

                for (int i = 0; i < words.Length; i++)
                {

                    switch (words[i])
                    {
                        case "Age":
                            result += person.Age;
                            break;
                        case "EyeColor":
                            result += person.EyeColor;
                            break;
                        case "Name":
                            result += person.Name;
                            break;
                        case "Gender":
                            result += person.Gender;
                            break;
                        case "Company":
                            result += person.Company;
                            break;
                        case "Address":
                            result += person.Address;
                            break;
                        case "Salary":
                            result += person.Salary;
                            break;
                        default:
                            break;
                    }
                    result += "\r\n";

                }
                result += "\n";
            }
            StreamWriter sw = new StreamWriter(@$"AllPerson.csv", true);
            {
                sw.Write(result);
            }
            sw.Write("\r\n");
            sw.Flush();
            sw.Close();
        }
    }
}
