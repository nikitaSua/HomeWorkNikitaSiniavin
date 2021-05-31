using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TDDPpractice.HelpClasses;

namespace TDDPpractice
{
    public class StringCalculator
    {
        private NumParserInStr numParserInStr;
        public StringCalculator(NumParserInStr numParserInStr)
        {
            this.numParserInStr = numParserInStr;
        }
        //public int Add(string numbers)
        //{
        //    int finalSum = 0;
        //    List<int> parsedNums = new List<int>();
        //    string pattern = @"\d*";

        //    if (numbers == "")
        //    {
        //        parsedNums.Add(0);
        //        return 0;
        //    }

        //    var answer = Regex.Matches(numbers, pattern);

        //    foreach (var item in answer)
        //    {
        //        int number;
        //        bool success = Int32.TryParse(item.ToString(), out number);
        //        if (success)
        //        {
        //            parsedNums.Add(number);
        //        }
        //        else
        //        {

        //        }
        //    }

        //    foreach (int item in parsedNums)
        //    {
        //        finalSum += item;
        //    }
        //    return finalSum;
        //}

        public int Add(string numbers)
        {
            int finalSum = 0;

            if (numParserInStr.NegativeCheck(numbers)!="")
            {
                //throw new NegativesNotAllowedException($"negative nums not alowed numbers are {numParserInStr.NegativeCheck(numbers)}");
            }

            if (numbers == "")
            {
                return 0;
            }

            

            string delimiter = numParserInStr.GetDelimiter(numbers);
            string[] separetedNums = numbers.Split(delimiter);

            foreach (var item in separetedNums)
            {
                int parsedNumber;
                bool success = Int32.TryParse(item.ToString(), out parsedNumber);
                if (success)
                {
                    finalSum += parsedNumber;
                }
                else
                {

                }
            }
            return finalSum;
        }

    }
}
