using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.FileTypes;

namespace Task_1.Parsers
{
    interface IParser
    {
        public AFile Parse(string parsedStr);
  
    }
}
