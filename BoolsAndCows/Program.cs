using System;

namespace BoolsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {


            TaskResolver brainComputer = new TaskResolver();
            brainComputer.InitAnswerVariants();
            while (true)
            {
                brainComputer.ComputerAnswerInit();
                Console.WriteLine($"Число предположительно  {brainComputer.CompTry}");
                Console.WriteLine("Количество быков:");
                brainComputer.NumBulls = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Количество коров:");
                brainComputer.NumCows = Convert.ToInt32(Console.ReadLine());
                if (brainComputer.NumBulls == 4)
                {
                    Console.WriteLine($"Компьютер побеждает так как угадал ваше число {brainComputer.CompTry}");
                    break;
                }
                else
                {
                    brainComputer.DelNums();
                }
            }
            Console.ReadKey();

        }

    }
}
