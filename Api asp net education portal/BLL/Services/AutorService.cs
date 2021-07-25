using AutoMapper;
using BLL.DtoModels;
using BLL.Interfaces;
using DAL.DBExt;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Services
{
    public class AutorService : IAutorService
    {
        private readonly IRepository repository;
        private readonly IMapper _mapper;

        public AutorService(IRepository repo)
        {
            this.repository = repo;
            var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile(new MapperProfile()));
            _mapper = new Mapper(mapperConfiguration);
        }
        public void AddAutor(AutorModel model)
        {
            Autor autor = _mapper.Map<Autor>(model);
            this.repository.AddAndSave<Autor>(autor);
        }
        public IEnumerable<AutorModel> GetAutors(Expression<Func<Autor, bool>> predicate)
        {
            return _mapper.Map<List<AutorModel>>(this.repository.GetFilteredByQuery<Autor>(predicate));
        }

        public AutorModel GetAutor(Expression<Func<Autor, bool>> predicate)
        {
            return _mapper.Map<AutorModel>(this.repository.FirstorDefault(predicate));
        }

        public AutorModel GetAutorById(int id)
        {
            return _mapper.Map<AutorModel>(this.repository.FirstorDefault<Autor>(x => x.Id == id));
        }

        public void RemoveAutor(int id)
        {
            var Autor = this.repository.FirstorDefault<Autor>(x => x.Id == id);
            if (Autor == null)
            {
                throw new NullReferenceException();
            }  
            this.repository.RemoveAndSave(Autor);
        }

        public void UpdateAutor(int id, AutorModel model)
        {
            var autor = this.repository.FirstorDefault<Autor>(x => x.Id == id);
            if (autor == null)
            {
                throw new NullReferenceException();
            }
            autor.Id = model.Id;
            autor.Name = model.Name;
            this.repository.UpdateAndSave(autor);
        }


    }
}
