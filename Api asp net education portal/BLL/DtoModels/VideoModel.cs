using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DtoModels
{
    public class VideoModel : MaterialModel
    {
        public string Quality { get; set; }
        public string Duration { get; set; }
    }
}
