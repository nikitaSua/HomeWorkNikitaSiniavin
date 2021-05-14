
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace practiceString
{
    public static class StringWorker
    {
        public static void GetNumsFromString(string str)
        {
            List<int> numbers = new List<int>();


            string pattern = @"\d?";
            for (int i = 0; i < str.Length; i++)
            {
                var temp = Regex.Match(str[i].ToString(), pattern);
                string val = temp.Value;
                if (val!="")
                {
                    numbers.Add(Convert.ToInt32(val));
                }
            }
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }

        public static void DevisionOfTwoNumbers(int a, int b)
        {

            double answer = (double)a / (double)b;
            answer = Math.Round(answer, 2);
            Console.WriteLine(answer);
        }

        public static void ExponentReader()
        {
            Console.WriteLine("число в экспоненциальной форме :");
            string InpStr = Console.ReadLine();

            string FirsPArtOFNumReg = (@"\d*");
            var FirsPArtTemp = Regex.Match(InpStr, FirsPArtOFNumReg);

            string LastPArtOFNumReg = (@"\d*$");
            var LastPArtTemp = Regex.Match(InpStr, LastPArtOFNumReg);

            string SignReg = (@"-");
            var SignTemp = Regex.Match(InpStr, SignReg);


            string val = FirsPArtTemp.Value;
            string LastValue = LastPArtTemp.Value;
            string SignTempval = SignTemp.Value;

            int answerA=0;


            if (SignTempval=="")
            {
                for (int i = 0; i < Convert.ToInt32(LastValue); i++)
                {
                    answerA *= Convert.ToInt32(val) * 10;
                }
                Console.WriteLine(answerA);
            }
            else
            {
                decimal a = Convert.ToInt32(val) / (10 * Convert.ToInt32(LastValue));
                Console.WriteLine(a);
            }

        }

        public static void DateInIso()
        {
            var a = DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
            Console.WriteLine(a);
        }

        public static void StringDateToDate(string str)
        {
            
            DateTime Arr = DateTime.ParseExact(str, "yyyy dd-MM", CultureInfo.InvariantCulture);

            Console.WriteLine($"{Arr.Year} {Arr.Day}-{Arr.Month}");
        }

        public static void IntNumbersStingSumParse(string str)
        {
            int totulSum=0;
            string[] nums = str.Split(",");

            foreach (var item in nums)
            {
                totulSum+=Convert.ToInt32(item);
            }
            Console.WriteLine(totulSum);
        }

        public static void RegExAnyLettersAnyNims(string str)
        {
            List<string> result = new List<string>();
            string[] splitedStrings = str.Split(" ");
            string pattern = @"\D*\d*";

            foreach (var item in splitedStrings)
            {
                
                var temp = Regex.Match(item, pattern);
                string val = temp.Value;
                if (val!="")
                {
                    result.Add(val);
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

        }

        
        public static void RegExUserPasswordValidatorSixSigns(string str)
        {

        }

    }
}
