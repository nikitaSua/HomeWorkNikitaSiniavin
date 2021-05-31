using System;
using TDDPpractice.HelpClasses;

namespace TDDPpractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            NumParserInStr numParserInStr = new NumParserInStr();
            string inp = "//*;\n1*;2*;3";
            var a=numParserInStr.ParseRegex(inp);

            StringCalculator stringCalculator = new StringCalculator(new NumParserInStr());
            int answer = stringCalculator.Add(inp);

            Console.WriteLine(answer);

        }
    }
}
