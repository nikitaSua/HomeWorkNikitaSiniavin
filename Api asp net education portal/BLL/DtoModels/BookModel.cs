using BLL.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DtoModels
{
    public class BookModel : MaterialModel
    {
        public int NumOfPage { get; set; }
        public int YearOfPublishing { get; set; }
    }
}
