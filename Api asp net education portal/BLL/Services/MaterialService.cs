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
    public class MaterialService : IMaterialService  
    {
        private readonly IRepository repository;
        private readonly IMapper _mapper;
        public MaterialService(IRepository repository)
        {
            this.repository = repository;
            var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile(new MapperProfile()));
            _mapper = new Mapper(mapperConfiguration);
        }
        public void AddArticle(ArticleModel articleModel)
        {
            Article article = _mapper.Map<Article>(articleModel);
            repository.AddAndSave(article);
        }
        public void AddBook(BookModel bookModel)
        {
            Book book = _mapper.Map<Book>(bookModel);
            repository.AddAndSave(book);
        }
        public void AddVideo(VideoModel videoModel)
        {
            Video video = _mapper.Map<Video>(videoModel);
            repository.AddAndSave(video);
        }
        public IEnumerable<ArticleModel> GetArticles(Expression<Func<Article, bool>> predicate) =>
            _mapper.Map<IEnumerable<ArticleModel>>(repository.GetFilteredByQuery<Article>(predicate));

        public ArticleModel GetArticle(Expression<Func<Article, bool>> predicate) =>
            _mapper.Map<ArticleModel>(repository.FirstorDefault<Article>(predicate));

        public IEnumerable<BookModel> GetBooks(Expression<Func<Book, bool>> predicate) =>
            _mapper.Map<IEnumerable<BookModel>>(repository.GetFilteredByQuery<Book>(predicate));

        public BookModel GetBook(Expression<Func<Book, bool>> predicate) =>
            _mapper.Map<BookModel>(repository.FirstorDefault<Book>(predicate));

        public IEnumerable<VideoModel> GetVideos(Expression<Func<Video, bool>> predicate) =>
            _mapper.Map<IEnumerable<VideoModel>>(repository.GetFilteredByQuery<Video>(predicate));

        public VideoModel GetVideo(Expression<Func<Video, bool>> predicate) =>
             _mapper.Map<VideoModel>(repository.FirstorDefault<Video>(predicate));

        public IEnumerable<MaterialModel> GetMaterials(Expression<Func<Material, bool>> predicate) =>
            _mapper.Map<IEnumerable<MaterialModel>>(repository.GetFilteredByQuery<Material>(predicate));

        public MaterialModel GetMaterial(Expression<Func<Material, bool>> predicate) =>
            _mapper.Map<MaterialModel>(repository.FirstorDefault<Material>(predicate));

        public void UpdateArticle(int id, ArticleModel model)
        {
            var article = this.repository.FirstorDefault<Article>(x => x.Id == id);
            var material = this.repository.FirstorDefault<Material>(x => x.Id == id);
            if (article == null)
            {
                throw new NullReferenceException();
            }
            article.PublicationDate = Convert.ToDateTime(model.PublicationDate);
            article.Link = model.Link;
            material.Name = model.Name;
            material.Description = model.Description;
            this.repository.UpdateAndSave(article);
            this.repository.UpdateAndSave(material);
        }

        public void UpdateVideo(int id, VideoModel model)
        {
            var video = this.repository.FirstorDefault<Video>(x => x.Id == id);
            var material = this.repository.FirstorDefault<Material>(x => x.Id == id);
            if (video == null)
            {
                throw new NullReferenceException();
            }
            video.Id = model.Id;
            video.Quality = model.Quality;
            video.Duration = model.Duration;
            material.Name = model.Name;
            material.Description = model.Description;
            this.repository.UpdateAndSave(video);
            this.repository.UpdateAndSave(material);
        }

        public void UpdateBook(int id, BookModel model)
        {
            var book = this.repository.FirstorDefault<Book>(x => x.Id == id);
            var material = this.repository.FirstorDefault<Material>(x => x.Id == id);
            if (book == null)
            {
                throw new NullReferenceException();
            }

            book.Id = model.Id;
            book.NumOfPage = model.NumOfPage;
            book.YearOfPublishing = model.YearOfPublishing;
            material.Name = model.Name;
            material.Description = model.Description;
            this.repository.UpdateAndSave(book);
            this.repository.UpdateAndSave(material);
        }

        public MaterialModel GetMaterialById(int id)
        {
            var entity = this.repository.FirstorDefault<Material>(x => x.Id == id);
            var model = _mapper.Map<MaterialModel>(entity);
            return model;
        }

        public void RemoveMaterial(int id)
        {
            var course = this.repository.FirstorDefault<Material>(x => x.Id == id);
            if (course == null)
            {
                throw new NullReferenceException();
            }
            this.repository.RemoveAndSave(course);
        }

    }
}
