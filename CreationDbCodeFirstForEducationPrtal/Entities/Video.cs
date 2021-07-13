using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationDbCodeFirstForEducationPrtal.Entities
{
    public class Video : Material
    {
        public string Quality { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
