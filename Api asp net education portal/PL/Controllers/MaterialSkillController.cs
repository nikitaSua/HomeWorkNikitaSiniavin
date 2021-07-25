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
    public class MaterialSkillController : ControllerBase
    {
        private readonly IMaterialSkillService materialSkillService;
        public MaterialSkillController(IMaterialSkillService MaterialSkillService)
        {
            this.materialSkillService = MaterialSkillService;
        }
        // GET: api/<MaterialSkillController>
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IEnumerable<MaterialSkillModel> Get()
        {
            return this.materialSkillService.GetMaterialSkills(x => true);
        }

        // GET api/<MaterialSkillController>/5
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public MaterialSkillModel GetMaterialSkill(int id)
        {
            return this.materialSkillService.GetMaterialSkillById(id);
        }

        // POST api/<MaterialSkillController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Post([FromBody] MaterialSkillModel model)
        {
            this.materialSkillService.AddMaterialSkill(model);
        }

        // PUT api/<MaterialSkillController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MaterialSkillModel model)
        {
            this.materialSkillService.UpdateMaterialSkill(id, model);
        }

        // DELETE api/<MaterialSkillController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.materialSkillService.RemoveMaterialSkill(id);
        }
    }
}
