using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoolsAndCows
{
    class TaskResolver
    {

        public List<int> UniqAnswers { get; set; }
        public int CompTry { get; set; }
        public int NumBulls { get; set; }
        public int NumCows { get; set; }

        public TaskResolver()
        {
            this.UniqAnswers = new List<int>();
        }

        public void InitAnswerVariants()
        {
            string[] AllPosibleNums = new string[10000];
            int[] tempIntAr=new int[10000];

            for (int i = 1000; i < 9999; i++)
            {
                int[] number = i.ToString().ToCharArray().Select(x => x - '0').ToArray();
                if (number[0] != number[1] && number[0] != number[2] && number[0] != number[3]
                    && number[1] != number[2] && number[1] != number[3] && number[2] != number[3])
                {
                    this.UniqAnswers.Add(i);
                }
            }
        }

        public void ComputerAnswerInit()
        {
            Random random = new Random();
            this.CompTry = this.UniqAnswers.ElementAt(random.Next(0, this.UniqAnswers.Count()));
        }

        public void DelNums()
        {

            List<int> result = new List<int>();
            foreach (var answ in this.UniqAnswers)
            {
                result.Add(answ);
            }

            int bulls = 0;
            int cows = 0;

            foreach (var answer in this.UniqAnswers)
            {
                CheckBullsCows(ref bulls, ref cows, answer);
                if (bulls != this.NumBulls || cows != this.NumCows)
                {
                    result.Remove(answer);
                }
                bulls = 0;
                cows = 0;
            }
            this.UniqAnswers = result;

        }


        public void CheckBullsCows(ref int bulls, ref int cows, int curNumber)
        {
            int[] number = curNumber.ToString().ToCharArray().Select(x => x - '0').ToArray();
            int[] compTry = this.CompTry.ToString().ToCharArray().Select(x => x - '0').ToArray();
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == compTry[i])
                    bulls++;
                else
                {
                    for (int t = 0; t < compTry.Length; t++)
                    {
                        if (number[i] == compTry[t])
                            cows++;
                    }
                }
            }
        }

    }
}
