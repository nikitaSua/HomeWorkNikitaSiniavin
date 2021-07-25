using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Article : Material
    {
        public DateTime PublicationDate { get; set; }
        public string Link { get; set; }
    }
}
