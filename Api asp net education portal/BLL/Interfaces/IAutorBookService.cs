using BLL.DtoModels;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Interfaces
{
    public interface IAutorBookService 
    {
        IEnumerable<AutorBookModel> GetAutorBooks(Expression<Func<AutorBook, bool>> predicate);

        AutorBookModel GetAutorBookById(int id);

        AutorBookModel GetAutorBook(Expression<Func<AutorBook, bool>> predicate);

        void AddAutorBook(AutorBookModel model);

        void UpdateAutorBook(int id, AutorBookModel model);

        void RemoveAutorBook(int id);
    }
}
