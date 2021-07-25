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
    public class AutorBookController : ControllerBase
    {
        private readonly IAutorBookService autorBookService;
        public AutorBookController(IAutorBookService autorBookService)
        {
            this.autorBookService = autorBookService;
        }
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IEnumerable<AutorBookModel> Get()
        {
            var autorBooks = autorBookService.GetAutorBooks(x => true);
            return autorBooks;
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, User")]
        public AutorBookModel GetDetails(int id)
        {
            var autorBook = autorBookService.GetAutorBookById(id);
            return autorBook;
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Post([FromBody] AutorBookModel model)
        {
            this.autorBookService.AddAutorBook(model);
        }
        // PUT api/<AutorBookController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AutorBookModel model)
        {
            this.autorBookService.UpdateAutorBook(id, model);
        }
        // DELETE api/<AutorBookController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            this.autorBookService.RemoveAutorBook(id);
        }
    }
}