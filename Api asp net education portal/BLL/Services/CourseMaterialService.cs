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
    public class CourseMaterialService : ICourseMaterialService
    {
        private readonly IRepository repository;
        private readonly IMapper _mapper;

        public CourseMaterialService(IRepository repo)
        {
            this.repository = repo;
            var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile(new MapperProfile()));
            _mapper = new Mapper(mapperConfiguration);
        }
        public void AddCourseMaterial(CourseMaterialModel model)
        {
            var material = this.repository.FirstorDefault<Material>(x => x.Id == model.MaterialId);
            var course = this.repository.FirstorDefault<Course>(x => x.Id == model.CourseId);
            CourseMaterial courseMaterial = new CourseMaterial() 
            { 
                Material = material,
                MaterialId = material.Id,
                Course = course,
                CourseId = course.Id
            };
            this.repository.AddAndSave<CourseMaterial>(courseMaterial);
        }
        public IEnumerable<CourseMaterialModel> GetCourseMaterials(Expression<Func<CourseMaterial, bool>> predicate)
        {
            var listCourseMaterial = this.repository.GetWithInclude<CourseMaterial>(predicate, p => p.Material, x => x.Course);
            var listmodel = new List<CourseMaterialModel>();
            foreach (var item in listCourseMaterial)
            {
                var model = new CourseMaterialModel();
                model.Id = item.Id;
                model.CourseId = item.CourseId;
                model.MaterialId = item.MaterialId;
                model.Course = _mapper.Map<CourseModel>(item.Course);
                model.Material = _mapper.Map<MaterialModel>(item.Material);
                listmodel.Add(model);
            }
            return listmodel;
        }


        public CourseMaterialModel GetCourseMaterial(Expression<Func<CourseMaterial, bool>> predicate)
        {
            return _mapper.Map<CourseMaterialModel>(this.repository.FirstorDefault(predicate));
        }

        public CourseMaterialModel GetCourseMaterialById(int id)
        {
            var entity = this.repository.FirstorDefault<CourseMaterial>(x => x.Id == id);
            var model = new CourseMaterialModel()
            {
                Id = entity.Id,
                Course = _mapper.Map<CourseModel>(entity.Course),
                Material = _mapper.Map<MaterialModel>(entity.Material),
                CourseId = entity.CourseId,
                MaterialId = entity.MaterialId
            };
            return model;
        }

        public void RemoveCourseMaterial(int id)
        {
            var courseMaterial = this.repository.FirstorDefault<CourseMaterial>(x => x.Id == id);
            if (courseMaterial == null)
            {
                throw new NullReferenceException();
            }   
            this.repository.RemoveAndSave(courseMaterial);
        }

        public void UpdateCourseMaterial(int id, CourseMaterialModel model)
        {
            var courseMaterial = this.repository.FirstorDefault<CourseMaterial>(x => x.Id == id);
            if (courseMaterial == null)
            {
                throw new NullReferenceException();
            } 
            courseMaterial.CourseId = model.CourseId;
            courseMaterial.MaterialId = model.MaterialId;
            courseMaterial.Course = _mapper.Map<Course>(model.Course);
            courseMaterial.Material = _mapper.Map<Material>(model.Material);
            this.repository.UpdateAndSave(courseMaterial);
        }

    }
}
