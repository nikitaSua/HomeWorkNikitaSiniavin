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
    public class BookController : ControllerBase
    {
        private readonly IMaterialService materialService;

        public BookController(IMaterialService materialService)
        {
            this.materialService = materialService;

        }
        // GET: api/<MaterialController>
        [HttpGet]
        //[Authorize(Roles = "Admin, User")]
        public IEnumerable<BookModel>   Get()
        {
            var result= this.materialService.GetBooks(x => true);
            return result.ToArray(); ;
        }
        // GET api/<MaterialController>/5
        //[Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public MaterialModel GetMaterial(int id)
        {
            return this.materialService.GetMaterialById(id);
        }
        // POST api/<MaterialController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Post([FromBody] BookModel model)
        {
            this.materialService.AddBook(model);
        }
        // PUT api/<MaterialController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BookModel model)
        {
            this.materialService.UpdateBook(id, model);
        }
        // DELETE api/<MaterialController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            this.materialService.RemoveMaterial(id);
        }
    }
}
