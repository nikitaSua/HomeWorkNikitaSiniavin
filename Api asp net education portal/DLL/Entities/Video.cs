using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Video : Material
    {
        public string Quality { get; set; }
        public string Duration { get; set; }
    }
}
