using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class AutorBook: IEntity
    {
        public int Id { get; set; }
        public int? AutorId { get; set; }
        public virtual Autor Autor { get; set; }
        public int? BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
