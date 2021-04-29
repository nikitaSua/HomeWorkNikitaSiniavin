using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.FileTypes;

namespace Task_1.Parsers
{
    public class MovieParser : IParser
    {
        public AFile Parse(string parsedStr)
        {
            string name = stringWorker.NameSearcher(parsedStr);
            string extension = stringWorker.ExtensionSearcher(parsedStr);
            string size = stringWorker.SizeSearcher(parsedStr);
            string resolution = stringWorker.ResolutionSearcher(parsedStr);
            string duration = stringWorker.DurationSearcher(parsedStr);

            return new MovieFile(name, extension, size, resolution, duration);
        }
        
    }
}
