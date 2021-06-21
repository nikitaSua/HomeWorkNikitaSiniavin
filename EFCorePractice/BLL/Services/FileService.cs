using EFCorePractice.Entities;
using EFCorePractice.Repositories;
using EfPractice.Date.Core.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FileService
    {
        private readonly IRepository repository = new EfRepository(new FileSystemConext());
        public IEnumerable<File> GetFiles(Expression<Func<File, bool>> predicate)
        {
            var files = this.repository.GetFilteredByQuery<File>(predicate);
            return files;
        }
        public File GetFile(Expression<Func<File, bool>> predicate)
        {
            var file=this.repository.FirstorDefault(predicate);
            return file;
        }
        public File GetFileById(int id)
        {
            var file=this.repository.FirstorDefault<File>(x => x.Id == id);
            return file;
        }
    }
}
