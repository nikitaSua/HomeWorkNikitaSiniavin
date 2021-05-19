using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    class FileWorker
    {

        public string[] GetFiles(string path)
        {
            try
            {
                // Only get files that begin with the letter "c".
                string[] dirs = Directory.GetFiles(path);
                Console.WriteLine("The number of files starting with c is {0}.", dirs.Length);
                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                }
                return dirs;
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            return new string[0];
        }

        public IEnumerable<string> GetDirectories(string CurentDirpath)
        {


            var dirList = Directory.GetDirectories(CurentDirpath).Concat(Directory.GetFiles(CurentDirpath));

            var resultDirectorys = Directory.GetDirectories(CurentDirpath).Concat(Directory.GetFiles(CurentDirpath));

            foreach (var dir in dirList)
            {
                var attributes = File.GetAttributes(dir);
                if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    resultDirectorys = resultDirectorys.Where(x => x != dir).ToArray();
            }
            return resultDirectorys;
        }


        public static IEnumerable<string> ReadLines(string path, int maxLineLength)
        {
            StringBuilder currentLine = new StringBuilder(maxLineLength);
            using (var reader = File.OpenText(path))
            {
                int i;
                while ((i = reader.Read()) > 0)
                {
                    char c = (char)i;
                    if (c == '\r' || c == '\n')
                    {
                        yield return currentLine.ToString();
                        currentLine.Length = 0;
                        continue;
                    }
                    currentLine.Append((char)c);
                    if (currentLine.Length > maxLineLength)
                    {
                        throw new InvalidOperationException("Max length exceeded");
                    }
                }
                if (currentLine.Length > 0)
                {
                    yield return currentLine.ToString();
                }
            }
        }



        
    }
}
