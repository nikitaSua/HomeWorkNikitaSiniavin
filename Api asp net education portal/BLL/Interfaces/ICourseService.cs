
using BLL.DtoModels;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Interfaces
{
    public interface ICourseService 
    {
        IEnumerable<CourseModel> GetCourses(Expression<Func<Course, bool>> predicate);

        CourseModel GetCourseById(int id);

        CourseModel GetCourse(Expression<Func<Course, bool>> predicate);

        void AddCourse(CourseModel model);

        void UpdateCourse(int id, CourseModel model);

        void RemoveCourse(int id);
    }
}
