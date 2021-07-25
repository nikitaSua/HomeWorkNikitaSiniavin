using BLL.DtoModels;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseUserController : ControllerBase
    {
        private readonly ICourseUserService courseUserService;
        public CourseUserController(ICourseUserService CourseUserService)
        {
            this.courseUserService = CourseUserService;
        }
        // GET: api/<CourseUserController>
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IEnumerable<CourseUserModel> Get()
        {
            return this.courseUserService.GetCourseUsers(x => true);
        }

        // GET api/<CourseUserController>/5
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public CourseUserModel GetCourseUser(int id)
        {
            return this.courseUserService.GetCourseUserById(id);
        }

        // POST api/<CourseUserController>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public void Post([FromBody] CourseUserModel model)
        {
            this.courseUserService.AddCourseUser(model);
        }

        // PUT api/<CourseUserController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CourseUserModel model)
        {
            this.courseUserService.UpdateCourseUser(id, model);
        }

        // DELETE api/<CourseUserController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.courseUserService.RemoveCourseUser(id);
        }
    }
}
