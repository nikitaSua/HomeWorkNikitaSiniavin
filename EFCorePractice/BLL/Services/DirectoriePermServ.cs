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
    public class DirectoriePermServ
    {

        private readonly IRepository repository = new EfRepository(new FileSystemConext());

        public IEnumerable<DirectoryPermission> GetDirectoryFiles(Expression<Func<DirectoryPermission, bool>> predicate)
        {
            var listOfFiles = this.repository.GetWithInclude<DirectoryPermission>(predicate, p => p.Directorie, u => u.User);
            return listOfFiles;
        }

    }
}
