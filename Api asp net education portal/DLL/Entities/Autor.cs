using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class Autor : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AutorBook> AutorBooks { get; set; }
        public Autor()
        {
            AutorBooks = new List<AutorBook>();
        }
    }
}
