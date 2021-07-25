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
    public class CourseUserService : ICourseUserService
    {
        private readonly IRepository repository;
        private readonly IMapper _mapper;
        //private readonly IUserService _userService;

        public CourseUserService(IRepository repo)
        {
            this.repository = repo;
            //this._userService = userService;
            var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile(new MapperProfile()));
            _mapper = new Mapper(mapperConfiguration);
        }
        public void AddCourseUser(CourseUserModel model)
        {
            var user = repository.FirstorDefault<User>(x => x.Id == model.UserId);
            var course = this.repository.FirstorDefault<Course>(x => x.Id == model.CourseId);
            CourseUser courseUser = new CourseUser()
            {
                UserId = user.Id,
                User = user,
                Course = course,
                CourseId = course.Id
            };
            this.repository.AddAndSave<CourseUser>(courseUser);
        }

        public IEnumerable<CourseUserModel> GetCourseUsers(Expression<Func<CourseUser, bool>> predicate)
        {
            var listCourseUser = this.repository.GetWithInclude(predicate, p=> p.Course, x => x.User);
            var listmodel = new List<CourseUserModel>();
            foreach (var item in listCourseUser)
            {
                var model = new CourseUserModel();
                model.Id = item.Id;
                model.CourseId = item.CourseId;
                model.UserId = item.UserId;
                model.Course = _mapper.Map<CourseModel>(item.Course);
                model.User = _mapper.Map<UserModel>(item.User);
                listmodel.Add(model);
            }
            return listmodel;
        }
        public CourseUserModel GetCourseUser(Expression<Func<CourseUser, bool>> predicate)
        {
            return _mapper.Map<CourseUserModel>(this.repository.FirstorDefault(predicate));
        }
        public CourseUserModel GetCourseUserById(int id)
        {
            var entity = this.repository.FirstorDefault<CourseUser>(x => x.Id == id);
            var model = new CourseUserModel()
            {
                Id = entity.Id,
                CourseId = entity.CourseId,
                UserId = entity.UserId,
                Course = _mapper.Map<CourseModel>(entity.Course),
                User = _mapper.Map<UserModel>(entity.User)
            };
            return model;
        }
        public void RemoveCourseUser(int id)
        {
            var courseUser = this.repository.FirstorDefault<CourseUser>(x => x.Id == id);
            if (courseUser == null)
            {
                throw new NullReferenceException();
            }
            this.repository.RemoveAndSave(courseUser);
        }
        public void UpdateCourseUser(int id, CourseUserModel model)
        {
            var courseUser = this.repository.FirstorDefault<CourseUser>(x => x.Id == id);
            if (courseUser == null)
            {
                throw new NullReferenceException();
            }  
            courseUser.CourseId = model.CourseId;
            courseUser.Course = _mapper.Map<Course>(model.Course);
            courseUser.User = _mapper.Map<User>(model.User);
            courseUser.UserId = model.UserId;
            this.repository.UpdateAndSave(courseUser);
        }

    }
}
