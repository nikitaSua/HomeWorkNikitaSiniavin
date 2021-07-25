using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Book: Material
    {
        public int NumOfPage { get; set; }
        public int YearOfPublishing { get; set; }
        public List<AutorBook> AutorBooks { get; set; }
        public Book()
        {
            this.AutorBooks = new List<AutorBook>();
        }
    }
}
