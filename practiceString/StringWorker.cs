
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
                if (val != "")
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
            int answerA = 0;
            if (SignTempval == "")
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
            int totulSum = 0;
            string[] nums = str.Split(",");

            foreach (var item in nums)
            {
                totulSum += Convert.ToInt32(item);
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
                if (val != "")
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
            string pattern = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$";

            if (Regex.IsMatch(str, pattern))
            {
                Console.WriteLine("Password is ok");
            }
            else Console.WriteLine("Wrong Password format");
        }
        public static void RegExUserPostCodeValidator(string str)
        {
            string pattern = @"[\d]{3}-[\d]{3}";

            if (Regex.IsMatch(str, pattern))
            {
                Console.WriteLine("Post Code is ok");
            }
            else Console.WriteLine("Wrong Post Code format");
        }
        public static void RegExPhoneNumberValidator(string str)
        {
            string pattern = ("[+][0-9]{3}-[0-9]{2}-[0-9]{3}-[0-9]{2}-[0-9]{2}");
            if (Regex.IsMatch(str, pattern))
            {
                Console.WriteLine("Phone number is ok");
            }
            else Console.WriteLine("Wrong phone number format");
        }
        public static void RegExPhoneNumberReplaser(string str)
        {
            string pattern = ("[+][0-9]{3}-[0-9]{2}-[0-9]{3}-[0-9]{2}-[0-9]{2}");
            string target = "+XXX-XX-XXX-XX-XX";
            Regex regex = new Regex(pattern);
            string result = regex.Replace(str, target);

            Console.WriteLine(result);
        }
        public static void FirstNameLatterReplaser(string[] str)
        {
            string pattern = (@"^\w*");
            var textInfo = new CultureInfo("ru-RU").TextInfo;
            List<string> UpperNames = new List<string>();

            foreach (string item in str)
            {
                var capitalizedText = textInfo.ToTitleCase(textInfo.ToLower(item));
                UpperNames.Add(capitalizedText);
            }
            foreach (var item in UpperNames)
            {
                Console.WriteLine(item);
            }
        }
        public static void DecoderBae64(string str)
        {
            var Converted = Convert.FromBase64String(str);
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(Converted));
        }
        static int partition<T>(T[] m, int a, int b)
        where T : IComparable<T>
        {
            int i = a;
            for (int j = a; j <= b; j++)         // просматриваем с a по b
            {
                if (m[j].CompareTo(m[b]) <= 0)  // если элемент m[j] не превосходит m[b],
                {
                    T t = m[i];                  // меняем местами m[j] и m[a], m[a+1], m[a+2] и так далее...
                    m[i] = m[j];                 // то есть переносим элементы меньшие m[b] в начало,
                    m[j] = t;                    // а затем и сам m[b] «сверху»
                    i++;                         // таким образом последний обмен: m[b] и m[i], после чего i++
                }
            }
            return i - 1;                        // в индексе i хранится <новая позиция элемента m[b]> + 1
        }
        public static void quicksort<T>(T[] m, int a, int b) where T : IComparable<T>// a - начало подмножества, b - конец
        {                                        // для первого вызова: a = 0, b = <элементов в массиве> - 1
            if (a >= b) return;
            int c = partition(m, a, b);
            quicksort(m, a, c - 1);
            quicksort(m, c + 1, b);
        }
    }
 }





