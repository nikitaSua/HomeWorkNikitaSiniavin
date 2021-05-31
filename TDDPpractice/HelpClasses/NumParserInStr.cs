using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TDDPpractice.HelpClasses
{
    public class NumParserInStr
    {
        public List<int> Parse(string nums)
        {
            List<int> parsedNums = new List<int>();
            string[] separatedNums = nums.Split(",");
            if (nums == "")
            {
                parsedNums.Add(0);
                return parsedNums;
            }
            foreach (string item in separatedNums)
            {
                int number;
                bool success = Int32.TryParse(item, out number);
                if (success)
                {
                    parsedNums.Add(number);
                }
                else
                {
                    parsedNums.Add(0);
                }
            }
            return parsedNums;

        }
        public List<int> ParseRegex(string nums)
        {
            List<int> parsedNums = new List<int>();
            string pattern = @"\d*";
            if (nums == "")
            {
                parsedNums.Add(0);
                return parsedNums;
            }

            var answer = Regex.Matches(nums, pattern);

            foreach (var item in answer)
            {
                int number;
                bool success = Int32.TryParse(item.ToString(), out number);
                if (success)
                {
                    parsedNums.Add(number);
                }
                else
                {

                }
            }
            return parsedNums;
        }

        public string GetDelimiter(string nums)
        {
            string pattern = @"//.*[\n]";
            Regex regexPat = new Regex(@"^//");
            Regex regexNewStrPat = new Regex(@"[\n]");
            Match m = Regex.Match(nums, pattern);
            var delimeter = m.ToString();
            string result = regexPat.Replace(delimeter, "");
            string finalResult = regexNewStrPat.Replace(result, "");

            if (finalResult == "")
            {
                return ",";
            }
            return finalResult;
        }
        public string NegativeCheck(string nums)
        {

            List<string> negativeNums = new List<string>();
            string pattern = @"-\d*";
            var answer = Regex.Matches(nums, pattern);

            if (answer!=null)
            {
                foreach (var item in answer)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            return negativeNums.ToString();
        }
    }
}
