using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreedsTask
{
    public class MinNumInArr : ITask
    {
        public void Execute()
        {
            Random rnd = new Random();
            int[] resultMas = new int[100];
            for (int i = 0; i < resultMas.Length; i++)
            {
                resultMas[i] = rnd.Next(0, 10);
            }
            int answer = resultMas.Min();
            Console.WriteLine($"Min number in array {answer}");
        }
    }
}
