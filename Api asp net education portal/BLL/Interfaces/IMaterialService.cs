using BLL.DtoModels;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Interfaces
{
    public interface IMaterialService 
    {
        void AddArticle(ArticleModel articleModel);
        void AddBook(BookModel bookModel);
        void AddVideo(VideoModel videoModel);
        IEnumerable<ArticleModel> GetArticles(Expression<Func<Article, bool>> predicate);
        IEnumerable<BookModel> GetBooks(Expression<Func<Book, bool>> predicate);
        IEnumerable<VideoModel> GetVideos(Expression<Func<Video, bool>> predicate);
        IEnumerable<MaterialModel> GetMaterials(Expression<Func<Material, bool>> predicate);
        ArticleModel GetArticle(Expression<Func<Article, bool>> predicate);
        BookModel GetBook(Expression<Func<Book, bool>> predicate);
        VideoModel GetVideo(Expression<Func<Video, bool>> predicate);
        MaterialModel GetMaterial(Expression<Func<Material, bool>> predicate);
        void UpdateArticle(int id, ArticleModel model);
        void UpdateVideo(int id, VideoModel model);
        void UpdateBook(int id, BookModel model);
        MaterialModel GetMaterialById(int id);
        void RemoveMaterial(int id);
    }
}
