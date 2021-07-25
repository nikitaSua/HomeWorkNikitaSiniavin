using BLL.DtoModels;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;
        public CourseController(ICourseService CourseService)
        {
            this.courseService = CourseService;
        }
        // GET: api/<CourseController>
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IEnumerable<CourseModel> Get()
        {
            return this.courseService.GetCourses(x => true);
        }

        //GET api/<CourseController>/5
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public CourseModel GetCourse(int id)
        {
            return this.courseService.GetCourseById(id);
        }

        // POST api/<CourseController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Post([FromBody] CourseModel model)
        {
            this.courseService.AddCourse(model);
        }

        // PUT api/<CourseController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CourseModel model)
        {
            this.courseService.UpdateCourse(id, model);
        }

        // DELETE api/<CourseController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.courseService.RemoveCourse(id);
        }
    }
}
