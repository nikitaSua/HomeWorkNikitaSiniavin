using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DtoModels
{
    public class AutorBookModel
    {
        public int Id { get; set; }
        public int? AutorId { get; set; }
        public virtual AutorModel Autor { get; set; }
        public int? BookId { get; set; }
        public virtual BookModel Book { get; set; }
    }
}
