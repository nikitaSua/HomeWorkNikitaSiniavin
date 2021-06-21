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
    public class DirectorieService
    {
        private readonly IRepository repository = new EfRepository(new FileSystemConext());
        public IEnumerable<Directorie> GetDirectorie(Expression<Func<Directorie, bool>> predicate)
        {
            var directories = this.repository.GetFilteredByQuery<Directorie>(predicate);
            return directories;
        }

        public IEnumerable<Directorie> GetFilesInDirectory(Expression<Func<Directorie, bool>> predicate)
        {
            //var file = this.repository.GetWithInclude<Directorie>(predicate, p => p., x => x.Skill);
            var DirWitFile = this.repository.GetWithInclude<Directorie>(predicate, d => d.Title, d => d.Files);
            return DirWitFile;
        }





    }

}
