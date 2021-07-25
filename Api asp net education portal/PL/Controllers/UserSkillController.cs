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
    public class UserSkillController : ControllerBase
    {
        private readonly IUserSkillService userSkillService;
        public UserSkillController(IUserSkillService UserSkillService)
        {
            this.userSkillService = UserSkillService;
        }
        // GET: api/<UserSkillController>
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public IEnumerable<UserSkillModel> Get()
        {
            return this.userSkillService.GetUserSkills(x => true);
        }

        // GET api/<UserSkillController>/5
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public UserSkillModel GetUserSkill(int id)
        {
            return this.userSkillService.GetUserSkillById(id);
        }

        // POST api/<UserSkillController>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public void Post([FromBody] UserSkillModel model)
        {
            this.userSkillService.AddUserSkill(model);
        }

        // PUT api/<UserSkillController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserSkillModel model)
        {
            this.userSkillService.UpdateUserSkill(id, model);
        }

        // DELETE api/<UserSkillController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.userSkillService.RemoveUserSkill(id);
        }
    }
}
