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
    public class UserService : IUserService
    {
        private readonly IRepository repository;
        private readonly IUserSkillService userSkillService;
        private readonly IMaterialSkillService materialskillService;
        private readonly ICourseUserService courseUserService;
        private readonly ICourseMaterialService courseMaterialService;
        private readonly ICourseService courseService;
        private readonly ISkillService skillService;
        private readonly IMapper _mapper;

        public UserService(IUserSkillService userSkillService,
            IMaterialSkillService materialskillService,
            ISkillService skillService,
            ICourseUserService courseUserService,
            ICourseMaterialService courseMaterialService,
            ICourseService courseService,
            IRepository repository)
        {
            this.skillService = skillService;
            this.userSkillService = userSkillService;
            this.materialskillService = materialskillService;
            this.courseUserService = courseUserService;
            this.courseMaterialService = courseMaterialService;
            this.courseService = courseService;
            this.repository = repository;
            var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile(new MapperProfile()));
            _mapper = new Mapper(mapperConfiguration);
        }
        public IEnumerable<SkillModel> GetUserSkills(string email)
        {
            var user = repository.FirstorDefault<User>(x => x.Email == email);
            var skills = new List<SkillModel>();
            foreach (var userSkill in this.userSkillService.GetUserSkills(x => x.UserId == user.Id))
            {
                var skill = this.skillService.GetSkill(x => x.Id == userSkill.SkillId);
                skills.Add(skill);
            }
            return skills;
        }

        public void UserPassesCourse(int courseId, string email)
        {
            var user = repository.FirstorDefault<User>(x => x.Email == email);
            var courseUserModel = new CourseUserModel { CourseId = courseId, UserId = user.Id };//*******
            this.courseUserService.AddCourseUser(courseUserModel);
            IEnumerable<MaterialModel> listMaterialsInCourse = courseMaterialService.GetCourseMaterials(x => x.CourseId == courseId).Select(x => x.Material);
            List<MaterialSkillModel> listMaterialSkills = new List<MaterialSkillModel>();
            foreach (var material in listMaterialsInCourse)
            {
                listMaterialSkills.Add(materialskillService.GetMaterialSkill(x => x.MaterialId == material.Id));
            }
            foreach (var materialSkill in listMaterialSkills)
            {
                var sameSkill = this.userSkillService.GetUserSkill(x => x.SkillId == materialSkill.SkillId && x.UserId == user.Id);
                var userSkillModel = new UserSkillModel() { UserId = user.Id, SkillId = materialSkill.SkillId, Level = materialSkill.Level };
                if (sameSkill != null)
                {
                    if (sameSkill.Level < userSkillModel.Level)
                    {
                        this.userSkillService.UpdateUserSkill(sameSkill.Id, userSkillModel);
                    }
                }
                else
                {
                    this.userSkillService.AddUserSkill(userSkillModel);
                }
            }
        }
        public IEnumerable<CourseModel> GetUserCourse(string email)
        {
            //a
            var user = repository.FirstorDefault<User>(x => x.Email == email);
            return this.courseUserService.GetCourseUsers(x => x.UserId == user.Id).Select(x => x.Course);
        }
        public IEnumerable<MaterialModel> GetUserMaterials(string email)
        {
            var user = repository.FirstorDefault<User>(x => x.Email == email);
            var courses = this.courseUserService.GetCourseUsers(x => x.UserId == user.Id).Select(x => x.Course);
            var resultList = new List<MaterialModel>();
            foreach (var course in courses)
            {
                var materialModels = this.courseMaterialService.GetCourseMaterials(x => x.CourseId == course.Id).Select(x => x.Material);
                foreach (var material in materialModels)
                {
                    resultList.Add(material);
                }
            }
            return resultList.Distinct<MaterialModel>();
        }
        public IEnumerable<MaterialModel> GetMaterialsInCourse(int courseId, string email)
        {
            var userMaterials = GetUserMaterials(email);
            var materials = this.courseMaterialService.GetCourseMaterials(x => x.CourseId == courseId).Select(p => p.Material);
            return materials.Where(x => userMaterials.FirstOrDefault(p => p.Id == x.Id) == null);
        }
        public IEnumerable<CourseModel> GetCourseForUser(string email)
        {
            var userCourses = GetUserCourse(email);
            var courses = this.courseService.GetCourses(x => true);
            return courses.Where(x => userCourses.FirstOrDefault(p => p.Id == x.Id) == null);
        }

        public IEnumerable<UserModel> GetUsers(Expression<Func<Article, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public UserModel GetUserById(int id)
        {
            var user = _mapper.Map<UserModel>(repository.FirstorDefault<User>(x => x.Id == id));
            return user;

        }

        public UserModel GetUser(Expression<Func<User, bool>> predicate)
        {
            var geteduser = repository.FirstorDefault<User>(predicate);
            var user = _mapper.Map<UserModel>(repository.FirstorDefault<User>(predicate));
            return user;
        }

        public void UpdateUser(int id, UserModel model)
        {
            User user = this.repository.FirstorDefault<User>(x => x.Id == id);
            if (user == null)
            {
                throw new NullReferenceException();
            }
            user.Login = model.Login;
            user.Password = model.Password;
            user.Name = model.Name;
            user.Email = model.Email;
            user.RoleId = model.RoleId;
            this.repository.UpdateAndSave(user);
        }

        public void RemoveUser(int id)
        {
            User userEnt = repository.FirstorDefault<User>(x => x.Id == id);
            if (userEnt != null)
            {
                repository.RemoveAndSave<User>(userEnt);
            }
            else
                throw new NullReferenceException($"User with {id} doesn`t exist");

        }
        public string GetUserRole(UserModel userModel)
        {
            Role role = this.repository.FirstorDefault<Role>(r => r.Id == userModel.RoleId);
            if (role == null)
            {
                throw new NullReferenceException("Не получилос получить тип пользователя");
            }
            return role.Name;
        }
    }
}
