using AutoMapper;
using BLL.DtoModels;
using DAL.Entities;
using System;

namespace BLL
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Article, ArticleModel>().ReverseMap();
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<Video, VideoModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Skill, SkillModel>().ReverseMap();
            CreateMap<Material, MaterialModel>().ReverseMap();
            CreateMap<Autor, AutorModel>().ReverseMap();
            CreateMap<AutorBook, AutorBookModel>().ReverseMap();
            CreateMap<CourseMaterial, CourseMaterialModel>().ReverseMap();
            CreateMap<CourseUser, CourseUserModel>().ReverseMap();
            CreateMap<MaterialSkill, MaterialSkillModel>().ReverseMap();
            CreateMap<UserSkill, UserSkillModel>().ReverseMap();
            CreateMap<Course, CourseModel>().ReverseMap();
            CreateMap<UserModel, RegisterModel>().ReverseMap();
            //***
            CreateMap<User, RegisterModel>().ReverseMap();
        }
    }
}
