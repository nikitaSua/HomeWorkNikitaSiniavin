using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.FileTypes
{
    class ImageFile:AFile
    {
        public string Resolution { get; set; }
        public ImageFile(string name, string extension, string size, string resolution) : base(name, extension, size)
        {
            this.Resolution = resolution;
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"    Resolution:{Resolution}");
        }
    }
}
