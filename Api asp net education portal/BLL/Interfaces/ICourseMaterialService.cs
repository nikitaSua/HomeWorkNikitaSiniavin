
using BLL.DtoModels;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Interfaces
{
    public interface ICourseMaterialService 
    {
        IEnumerable<CourseMaterialModel> GetCourseMaterials(Expression<Func<CourseMaterial, bool>> predicate);

        CourseMaterialModel GetCourseMaterialById(int id);

        CourseMaterialModel GetCourseMaterial(Expression<Func<CourseMaterial, bool>> predicate);

        void AddCourseMaterial(CourseMaterialModel model);

        void UpdateCourseMaterial(int id, CourseMaterialModel model);

        void RemoveCourseMaterial(int id);
    }
}
