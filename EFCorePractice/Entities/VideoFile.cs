using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePractice.Entities
{
    public class VideoFile : File
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
