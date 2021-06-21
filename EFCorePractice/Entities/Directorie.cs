using EFCorePractice.Entities;
using EfPractice.Date.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePractice.Entities
{
    public class Directorie:IEntity
    {
        public int Id { get; set; }
        public int? ParentDirectory { get; set; }
        public string Title { get; set; }
        public ICollection<DirectoryPermission> DirectoryPermissions { get; set; }
        public ICollection<File> Files { get; set; }

    }
}
