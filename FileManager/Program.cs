using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {

            FileWorker fileWorker = new FileWorker();
            string CurrentDirectory  = @"C:\";

            while (true)
            {
                IEnumerable<string> catalogsFiles = fileWorker.GetDirectories(CurrentDirectory);
                foreach (var item in catalogsFiles)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Select the required directory: (Press .. to exit)");
                var answer = Console.ReadLine();
                if (answer == @"..")
                {
                    var parsedDir = CurrentDirectory.Split(@"\");
                    parsedDir = parsedDir.Where(x => x != parsedDir.TakeLast(2).Last() && x != parsedDir.TakeLast(2).First()).ToArray();
                    CurrentDirectory = string.Join(@"\", parsedDir.Select(x => x));
                }
                else
                {
                    var chekVar = CurrentDirectory + answer;
                    if (Directory.Exists(chekVar + @"\"))
                    {
                        CurrentDirectory += answer + @"\";
                    }
                    else if (File.Exists(chekVar))
                    {
                        IEnumerable<string> listSring;
                        if (Directory.GetFiles(CurrentDirectory, "*.txt").Where(x => x == chekVar).Count() == 1)
                        {
                            listSring = FileWorker.ReadLines(chekVar, 1024);
                            foreach (var item in listSring)
                            {
                                Console.WriteLine(item);
                            }
                        }

                        else
                        {
                            listSring = FileWorker.ReadLines(chekVar, 2048);
                            foreach (var item in listSring)
                            {
                                foreach (var item1 in item.ToCharArray())
                                {
                                    var intItem = Convert.ToInt32(item1);
                                    var bytes = BitConverter.GetBytes(intItem);
                                    string intValue = BitConverter.ToString(bytes);
                                    Console.WriteLine(intValue);
                                }
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid data entered");
                    }
                }
            }

        }
    }
}
