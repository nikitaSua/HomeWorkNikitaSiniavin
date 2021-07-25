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
    public class CourseMaterialController : ControllerBase
    {
        private readonly ICourseMaterialService courseMaterialService;
        public CourseMaterialController(ICourseMaterialService CourseMaterialService)
        {
            this.courseMaterialService = CourseMaterialService;
        }
        // GET: api/<CourseMaterialController>
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IEnumerable<CourseMaterialModel> Get()
        {
            return this.courseMaterialService.GetCourseMaterials(x => true);
        }
        //GET api/<CourseMaterialController>/5
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public CourseMaterialModel GetCourseMaterial(int id)
        {
            return this.courseMaterialService.GetCourseMaterialById(id);
        }

        // POST api/<CourseMaterialController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Post([FromBody] CourseMaterialModel model)
        {
            this.courseMaterialService.AddCourseMaterial(model);
        }

        // PUT api/<CourseMaterialController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public void Put(int id, [FromBody] CourseMaterialModel model)
        {
            this.courseMaterialService.UpdateCourseMaterial(id, model);
        }

        // DELETE api/<CourseMaterialController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.courseMaterialService.RemoveCourseMaterial(id);
        }
    }
}
