using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreedsTask.Tasks;

namespace ThreedsTask
{
    public class intermediateArr : ITaskpPrameterized
    {
        public void Execute( int statrt , int end)
        {
            Random rnd = new Random();
            int[] resultMas = new int[100];
            for (int i = 0; i < resultMas.Length; i++)
            {
                resultMas[i] = rnd.Next(0, 10);
            }
            List<int> copyedArr = new List<int>();

            for (int i = statrt; i <= end; i++)
            {
                copyedArr.Add(resultMas[i]);
            }
            int[] answer = copyedArr.ToArray();
            foreach (var item in answer)
            {
                Console.WriteLine(string.Join(" , ", item));
            }

        }

        public void ExecuteTask(object parametrs)
        {
            Parametrs parametrs1 = (Parametrs)parametrs;
            Random random = new Random();
            int[] mas = new int[100];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = random.Next(0, 99);
            }
            List<int> resultList = new List<int>();
            for (int i = parametrs1.start; i < mas.Length; i++)
            {
                if (i < parametrs1.end)
                    resultList.Add(mas[i]);
                else
                    break;
            }
            int[] resultMas = resultList.ToArray();
            foreach (var item in resultMas)
            {
                Console.Write(string.Join(" , ", $"{item}"));
            }
        }
    }
}

