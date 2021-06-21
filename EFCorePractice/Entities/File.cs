using EfPractice.Date.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePractice.Entities
{
    public class File : IEntity
    {
        public int Id { get; set; }
        public int? DirectoryId { get; set; }
        public string Title { get; set; }
        public string Extension { get; set; }
        public int Size { get; set; }
        public Directorie Directorie { get; set; }
        public ICollection<FilePermission> FilePermissions { get; set; }
        //public TextFile TextFile { get; set; }
        //public ImageFile ImageFile { get; set; }

        //public VideoFile VideoFile { get; set; }
        //public AudioFile AudioFile { get; set; }
    }
}
