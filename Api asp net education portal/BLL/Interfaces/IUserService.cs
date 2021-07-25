using BLL.DtoModels;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<SkillModel> GetUserSkills(string email);
        IEnumerable<CourseModel> GetUserCourse(string email);
        IEnumerable<MaterialModel> GetUserMaterials(string email);
        IEnumerable<MaterialModel> GetMaterialsInCourse(int courseId, string email);
        IEnumerable<CourseModel> GetCourseForUser(string email);
        IEnumerable<UserModel> GetUsers(Expression<Func<Article, bool>> predicate);
        public string GetUserRole(UserModel userModel);
        UserModel GetUserById(int id);
        UserModel GetUser(Expression<Func<User, bool>> predicate);

        void UpdateUser(int id, UserModel model);
        void UserPassesCourse(int courseId, string email);
        void RemoveUser(int id);
    }
}
