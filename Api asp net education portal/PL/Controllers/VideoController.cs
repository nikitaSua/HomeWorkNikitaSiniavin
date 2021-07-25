using BLL.DtoModels;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Controllers
{
    [Route("api/[controller]")]
    public class VideoController : Controller
    {
        private readonly IMaterialService materialService;
        public VideoController(IMaterialService materialService)
        {
            this.materialService = materialService;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, User")]
        public IEnumerable<VideoModel> Get()
        {
            var videos = materialService.GetVideos(x => true);
            return videos;
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, User")]
        public MaterialModel GetMaterial(int id)
        {
            MaterialModel video = materialService.GetMaterialById(id);
            return video;
        }

        // POST api/<MaterialController>
        [HttpPost]
        public void Post([FromBody] VideoModel model)
        {
            this.materialService.AddVideo(model);
        }
        // PUT api/<MaterialController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] VideoModel model)
        {
            this.materialService.UpdateVideo(id, model);
        }

        // DELETE api/<MaterialController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.materialService.RemoveMaterial(id);
        }

    }
}
