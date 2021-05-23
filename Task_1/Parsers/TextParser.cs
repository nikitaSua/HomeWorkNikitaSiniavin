using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.FileTypes;

namespace Task_1.Parsers
{
    public class TextParser : IParser
    {
        public AFile Parse(string parsedStr)
        {
            string name = stringWorker.NameSearcher(parsedStr);
            string extension = stringWorker.ExtensionSearcher(parsedStr);
            string size = stringWorker.SizeSearcher(parsedStr);
            string content = stringWorker.ContentSearcher(parsedStr);

            return new TextFile(name, extension, size, content);
        }
    }
}
