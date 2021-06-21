using EfPractice.Date.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePractice.Entities
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PaswordHash { get; set; }

        public ICollection<DirectoryPermission> DirectoryPermissions { get; set; }
        public ICollection<FilePermission> FilePermissions { get; set; }
        
    }
}
