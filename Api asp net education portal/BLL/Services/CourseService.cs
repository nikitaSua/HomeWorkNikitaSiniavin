using AutoMapper;
using BLL.DtoModels;
using BLL.Interfaces;
using DAL.DBExt;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository repository;
        private readonly IMapper _mapper;

        public CourseService(IRepository repository)
        {
            this.repository = repository;
            var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile(new MapperProfile()));
            _mapper = new Mapper(mapperConfiguration);
        }
        public void AddCourse(CourseModel model)
        {
            var course = _mapper.Map<Course>(model);
            repository.AddAndSave(course);
        }
        public IEnumerable<CourseModel> GetCourses(Expression<Func<Course, bool>> predicate)
        {
            var courses = repository.GetFilteredByQuery<Course>(predicate);
            return _mapper.Map<List<CourseModel>>(courses);
        }
        public CourseModel GetCourse(Expression<Func<Course, bool>> predicate)
        {
            return _mapper.Map<CourseModel>(this.repository.FirstorDefault(predicate));
        }

        public CourseModel GetCourseById(int id)
        {
            var entity = this.repository.FirstorDefault<Course>(x => x.Id == id);
            var model = _mapper.Map<CourseModel>(entity);
            return model;
        }

        public void RemoveCourse(int id)
        {
            var course = this.repository.FirstorDefault<Course>(x => x.Id == id);
            if (course == null)
            {
                throw new NullReferenceException();
            }  
            this.repository.RemoveAndSave(course);
        }

        public void UpdateCourse(int id, CourseModel model)
        {
            var course = this.repository.FirstorDefault<Course>(x => x.Id == id);
            if (course == null)
            {
                throw new NullReferenceException();
            }  
            course.Id = model.Id;
            course.Name = model.Name;
            course.Description = model.Description;
            this.repository.UpdateAndSave(course);
        }

    }
}
