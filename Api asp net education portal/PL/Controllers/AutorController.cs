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
    public class AutorController : ControllerBase
    {
        private readonly IAutorService autorService;
        public AutorController(IAutorService autorService)
        {
            this.autorService = autorService;
        }
        // GET: api/<AutorController>
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IEnumerable<AutorModel> Get()
        {
            return this.autorService.GetAutors(x => true);
        }

        // GET api/<AutorController>/5
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public AutorModel GetAutor(int id)
        {
            return this.autorService.GetAutorById(id);
        }

        // POST api/<AutorController>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public void Post([FromBody] AutorModel model)
        {
            this.autorService.AddAutor(model);
        }

        // PUT api/<AutorController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public void Put(int id, [FromBody] AutorModel model)
        {
            this.autorService.UpdateAutor(id, model);
        }

        // DELETE api/<AutorController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.autorService.RemoveAutor(id);
        }
    }
}
