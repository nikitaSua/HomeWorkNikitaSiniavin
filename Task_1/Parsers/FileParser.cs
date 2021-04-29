using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.FileTypes;

namespace Task_1.Parsers
{
    public class FileParser
    {

        private TextParser Tp = new TextParser();
        private ImageParser Ip = new ImageParser();
        private MovieParser Mp = new MovieParser();


        public List<AFile> Parse(string parsedStr)
        {
            List<AFile> files= new List<AFile>();
            string[] separatedStr = parsedStr.Split("\n");
            for (int i = 0; i < separatedStr.Length; i++)
            {
                if (separatedStr[i].Contains("Text"))
                {
                    files.Add(Tp.Parse(separatedStr[i]));
                }
                if (separatedStr[i].Contains("Movie"))
                {
                    files.Add(Mp.Parse(separatedStr[i]));
                }
                if (separatedStr[i].Contains("Image"))
                {
                    files.Add(Ip.Parse(separatedStr[i]));
                }
                
            }
            return files;
        }


    }
}
