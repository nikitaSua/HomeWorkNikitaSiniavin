using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.FileTypes
{
    
    public abstract class AFile
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Size { get; set; }
        public decimal ConvertedSize { get; set; }
        public AFile(string name, string extension, string size)
        {
            this.Name = name;
            this.Extension = extension;
            this.Size = size;
            this.ConvertedSize = Convertor.MyConvert(size);
        }
        public virtual void Display()
        {
            Console.WriteLine($"  {Name}");
            Console.WriteLine($"    Extension:{Extension}");
            Console.WriteLine($"    Size:{Size}");
            //Console.WriteLine($"    ConvertedSize:{ConvertedSize}");
        }


    }
}
