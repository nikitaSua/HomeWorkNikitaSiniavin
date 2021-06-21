using EfPractice.Date.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePractice.Entities
{
    public class FilePermission:IEntity
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public User User { get; set; }
        public File File { get; set; }
    }
}
