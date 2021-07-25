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
    public class ArticleController : ControllerBase
    {
        private readonly IMaterialService _materialService;
        public ArticleController(IMaterialService materialService)
        {
            this._materialService = materialService;
        }
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IEnumerable<ArticleModel> Get()
        {
            var article = _materialService.GetArticles(b => true);
            return article;
        }
        // GET api/<MaterialController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, User")]
        public MaterialModel GetMaterial(int id)
        {
            return this._materialService.GetMaterialById(id);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Post([FromBody] ArticleModel model)
        {
            this._materialService.AddArticle(model);
        }

        // PUT api/<MaterialController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public void Put(int id, [FromBody] ArticleModel model)
        {
            this._materialService.UpdateArticle(id, model);
        }
        // DELETE api/<MaterialController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._materialService.RemoveMaterial(id);
        }
    }
}