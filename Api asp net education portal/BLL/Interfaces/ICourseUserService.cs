using BLL.DtoModels;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Interfaces
{
    public interface ICourseUserService 
    {
        IEnumerable<CourseUserModel> GetCourseUsers(Expression<Func<CourseUser, bool>> predicate);

        CourseUserModel GetCourseUserById(int id);

        CourseUserModel GetCourseUser(Expression<Func<CourseUser, bool>> predicate);

        void AddCourseUser(CourseUserModel model);

        void UpdateCourseUser(int id, CourseUserModel model);

        void RemoveCourseUser(int id);
    }
}
