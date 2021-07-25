using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DtoModels
{
    public class ArticleModel : MaterialModel
    {
        public DateTime PublicationDate { get; set; }
        public string Link { get; set; }
    }
}
