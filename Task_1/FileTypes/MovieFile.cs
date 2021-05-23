using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.FileTypes
{
    class MovieFile:AFile
    {
        public string Duration { get; set; }
        public string Resolution { get; set; }
        public MovieFile(string name, string extension, string size, string resolution, string duration) : base(name, extension, size)
        {
            this.Resolution = resolution;
            this.Duration = duration;
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"    Length:{Duration}");
            Console.WriteLine($"    Resolution:{Resolution}");
        }
    }
}
