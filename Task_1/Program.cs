using System;
using System.Collections.Generic;
using Task_1.FileTypes;
using Task_1.Parsers;
using System.Linq;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FileParser a = new FileParser();
            string inputSTR = "Text:file.txt(6B);Some string content\n Image:img.bmp(19MB);1920х1080\n" +
                "Text:data.txt(12B);Another string\n Text:data1.txt(7B);Yet another string\n" +
                "Movie:logan.2017.mkv(19GB);1920х1080;2h12m";

            List<AFile> files = a.Parse(inputSTR);


            var sortedText = from f in files
                             where f.Extension=="txt"
                              orderby f.ConvertedSize
                              select f;
            var sortedImage = from f in files
                             where f.Extension == "bmp"
                              orderby f.ConvertedSize
                             select f;
            var sortedMovie = from f in files
                              where f.Extension == "mkv"
                              orderby f.ConvertedSize
                              select f;

            Console.WriteLine("Text files:");
            foreach (var item in sortedText)
            {
                item.Display();
            }
            Console.WriteLine("Movies:");
            foreach (var item in sortedMovie)
            {
                item.Display();
            }
            Console.WriteLine("Images:");
            foreach (var item in sortedImage)
            {
                item.Display();
            }


        }
    }
}
