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
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService materialService;
        public MaterialController(IMaterialService materialService)
        {
            this.materialService = materialService;
        }
        // GET: api/<MaterialController>
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public IEnumerable<MaterialModel> Get()
        {
            return this.materialService.GetMaterials(x => true);
        }
    }
}
