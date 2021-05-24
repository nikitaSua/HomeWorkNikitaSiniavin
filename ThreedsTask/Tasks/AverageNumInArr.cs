using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreedsTask
{
    public class AverageNumInArr : ITask
    {
        public void Execute()
        {
            Random rnd = new Random();
            int[] resultMas = new int[100];
            for (int i = 0; i < resultMas.Length; i++)
            {
                resultMas[i] = rnd.Next(0, 10);
            }
            var answer = resultMas.Average();
            Console.WriteLine($"Avarage num in arr {answer}");
        }
    }
}
