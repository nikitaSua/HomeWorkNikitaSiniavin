using AutoMapper;
using BLL.Interfaces;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using DAL.DBExt;
using BLL.DtoModels;

namespace BLL.Services
{
    public class AutorBookService : IAutorBookService
    {
        private readonly IRepository repository;
        private readonly IMapper _mapper;

        public AutorBookService(IRepository repo)
        {
            this.repository = repo;
            var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile(new MapperProfile()));
            _mapper = new Mapper(mapperConfiguration);
        }
        public void AddAutorBook(AutorBookModel model)
        {
            var book = this.repository.FirstorDefault<Book>(x => x.Id == model.BookId);
            var autor = this.repository.FirstorDefault<Autor>(x => x.Id == model.AutorId);
            AutorBook autorBook = new AutorBook() 
            { 
                BookId = book.Id,
                Book = book,
                Autor = autor,
                AutorId = autor.Id
            };
            this.repository.AddAndSave<AutorBook>(autorBook);
        }

        public IEnumerable<AutorBookModel> GetAutorBooks(Expression<Func<AutorBook, bool>> predicate)
        {
            var listAutorBook = this.repository.GetWithInclude<AutorBook>(predicate, p => p.Autor, x => x.Book);
            var listmodel = new List<AutorBookModel>();
            foreach (var item in listAutorBook)
            {
                var model = new AutorBookModel();
                model.Id = item.Id;
                model.AutorId = item.AutorId;
                model.BookId = item.BookId;
                model.Autor = _mapper.Map<AutorModel>(item.Autor);
                model.Book = _mapper.Map<BookModel>(item.Book);
                listmodel.Add(model);
            }
            return listmodel;
        }


        public AutorBookModel GetAutorBook(Expression<Func<AutorBook, bool>> predicate)
        {
            return _mapper.Map<AutorBookModel>(this.repository.FirstorDefault(predicate));
        }

        public AutorBookModel GetAutorBookById(int id)
        {
            var entity = this.repository.FirstorDefault<AutorBook>(x => x.Id == id);
            var model = new AutorBookModel()
            {
                Id = entity.Id,
                Autor = _mapper.Map<AutorModel>(entity.Autor),
                AutorId = entity.AutorId,
                Book = _mapper.Map<BookModel>(entity.Book),
                BookId = entity.BookId
            };
           
            return model;
        }

        public void RemoveAutorBook(int id)
        {
            var autorBook = this.repository.FirstorDefault<AutorBook>(x => x.Id == id);
            if (autorBook == null)
            {
                throw new NullReferenceException();
            }
            this.repository.RemoveAndSave(autorBook);
        }

        public void UpdateAutorBook(int id, AutorBookModel model)
        {
            var autorBook = this.repository.FirstorDefault<AutorBook>(x => x.Id == id);
            if (autorBook == null)
            {
                throw new NullReferenceException();
            }
            autorBook.AutorId = model.AutorId;
            autorBook.Autor = _mapper.Map<Autor>(model.Autor);
            autorBook.Book = _mapper.Map<Book>(model.Book);
            autorBook.BookId = model.BookId;
            this.repository.UpdateAndSave(autorBook);
        }
    }
}
