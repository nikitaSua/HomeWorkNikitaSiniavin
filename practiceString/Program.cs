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
            StringWorker.RegExUserPasswordValidatorSixSigns("Aa3bvccc");
            StringWorker.RegExUserPostCodeValidator("123-123");
            StringWorker.RegExPhoneNumberValidator("+380-98-123-45-67");
            StringWorker.RegExPhoneNumberReplaser("+380-98-123-42-11");
            StringWorker.FirstNameLatterReplaser(new string[] { "иван иванов", "светлана иванова-петренко" });
            StringWorker.DecoderBae64("0JXRgdC70Lgg0YLRiyDRh9C40YLQsNC10YjRjCDRjdGC0L7RgiDRgtC10LrRgdGCLCDQt9C90LDRh9C40YIg0LfQsNC00LDQvdC40LUg0LLRi9C/0L7Qu9C90LXQvdC+INCy0LXRgNC90L4gOik=");
            
            double[] arr = { 9, 1.5, 34.4, 234, 1, 56.5 };
            StringWorker.quicksort<double>(arr, 0, arr.Length - 1);



        }
    }
}
