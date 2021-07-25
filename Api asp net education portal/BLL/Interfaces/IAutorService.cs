
using BLL.DtoModels;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Interfaces
{
    public interface IAutorService 
    {
        IEnumerable<AutorModel> GetAutors(Expression<Func<Autor, bool>> predicate);

        AutorModel GetAutorById(int id);

        AutorModel GetAutor(Expression<Func<Autor, bool>> predicate);

        void AddAutor(AutorModel model);

        void UpdateAutor(int id, AutorModel model);

        void RemoveAutor(int id);
    }
}
