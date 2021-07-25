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
    public class SkillController : ControllerBase
    {
        private readonly ISkillService skillService;
        public SkillController(ISkillService SkillService)
        {
            this.skillService = SkillService;
        }
        // GET: api/<SkillController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<SkillModel> Get()
        {
            return this.skillService.GetSkills(x => true);
        }

        // GET api/<SkillController>/5
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public SkillModel GetSkill(int id)
        {
            return this.skillService.GetSkillById(id);
        }

        // POST api/<SkillController>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public void Post([FromBody] SkillModel model)
        {
            this.skillService.AddSkill(model);
        }

        // PUT api/<SkillController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SkillModel model)
        {
            this.skillService.UpdateSkill(id, model);
        }

        // DELETE api/<SkillController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.skillService.RemoveSkill(id);
        }
    }
}
