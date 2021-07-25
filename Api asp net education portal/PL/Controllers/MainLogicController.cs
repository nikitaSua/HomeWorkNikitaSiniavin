using BLL.DtoModels;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainLogicController : Controller
    {
        private readonly ILogger<MainLogicController> _logger;
        private readonly ICourseService _courseService;
        private readonly IUserService _userService;
        private readonly IMaterialService _materiaService;
        private readonly ICourseMaterialService courseMaterialService;

        public MainLogicController(ILogger<MainLogicController> logger, 
            ICourseService courseService, 
            IUserService userService,
            ICourseMaterialService courseMaterialService,
            IMaterialService materiaService)
        {
            _logger = logger;
            this._courseService = courseService;
            this._userService = userService;
            this._materiaService = materiaService;
            this.courseMaterialService = courseMaterialService;
        }


        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IEnumerable<CourseModel> Index()
        {
            var courses = _courseService.GetCourses(c => true);
            if (courses==null)
            {
                _logger.LogWarning(Convert.ToString(HttpContext.Request.QueryString));
            }
            return  courses;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public bool Passes(int Id)
        {
            string email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            if (email==null)
            {
                _logger.LogWarning(Convert.ToString(HttpContext.Request.QueryString)+$"Course ID= {Id} email = {email}");
                return false;
            }
            _userService.UserPassesCourse(Id, email);
            return true;  //если истина то курс пройден
        }


        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public IEnumerable<SkillModel> GetedSkills()
        {
            string email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            var skills = _userService.GetUserSkills(email);
            if (skills == null)
            {
                _logger.LogCritical(Convert.ToString(HttpContext.Request.QueryString) + $"  email = {email}");
            }
            return skills;  //возвращает полученные навыки пользователя в результате прохождения курса
        }


        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public List<MaterialModel> GetCourseMaterial(int id)
        {
            var courseMat=courseMaterialService.GetCourseMaterials(x => x.CourseId == id);
            List<MaterialModel> materials = new List<MaterialModel>();
            try
            {
                foreach (var item in courseMat)
                {
                    materials.Add(_materiaService.GetMaterialById(Convert.ToInt32(item.MaterialId)));
                }
            }
            catch (Exception )
            {
                _logger.LogCritical(Convert.ToString(HttpContext.Request.QueryString) + $"Course Id= {id} ProblenOfGetting Materials");
                throw new Exception();
            }
            return materials;  //список материалов курса
        }


        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IEnumerable<CourseModel> GetPassedCourses()
        {
            string email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            var passedCourses = _userService.GetUserCourse(email);
            if (passedCourses == null)
            {
                _logger.LogInformation(Convert.ToString(HttpContext.Request.QueryString) + $"  email = {email}");
            }
            return passedCourses;  //выводит список пройденных материалов пользователем
        }
    }
}
