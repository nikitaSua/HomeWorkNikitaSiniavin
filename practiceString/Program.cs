using System;

namespace practiceString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            StringWorker.GetNumsFromString("avc222");
            StringWorker.DevisionOfTwoNumbers(3, 2);
            //StringWorker.ExponentReader();
            StringWorker.DateInIso();
            StringWorker.StringDateToDate("2016 21-07");
            StringWorker.IntNumbersStingSumParse("1,2,3");
            StringWorker.RegExAnyLettersAnyNims("avc123, arw456.");
        }
    }
}
