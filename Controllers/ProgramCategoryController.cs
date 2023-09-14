using Microsoft.AspNetCore.Mvc;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;
using TechnoAcademyApi.Services;

namespace TechnoAcademyApi.Controllers
{
    [Route("api/v1/programcategory")]
    [ApiController]
    public class ProgramCategoryController : ControllerBase
    {
        private readonly IProgramCategoryService _programCategoryService;
        
        public ProgramCategoryController(IProgramCategoryService programCategoryService)
        {
            _programCategoryService = programCategoryService;
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Create(ProgramCategory programCategory)
        {
            var res = await Task.FromResult(_programCategoryService.Create(programCategory));
            return res == null ? BadRequest() : new Response("success");
        }
        [HttpGet("{uuid}")]
        public async Task<ActionResult<Response>> GetByUUID(string uuid)
        {
            var res = await Task.FromResult(_programCategoryService.GetByUUID(uuid));
            return res == null ? NotFound() : new Response("success",res);
        }
        [HttpGet]
        public async Task<ActionResult<Response>> GetAll()
        {
            var res = await Task.FromResult(_programCategoryService.GetAll());
            return res == null ? BadRequest() : new Response("success",res);
        }
        [HttpPut("{uuid}")]
        public async Task<ActionResult<Response>> Update(string uuid, ProgramCategory programCategory)
        {
            var res = await Task.FromResult(_programCategoryService.Update(uuid,programCategory));
            return res == null ? NotFound() : new Response("success");
        }
        [HttpDelete("{uuid}")]
        public async Task<ActionResult<Response>> Delete(string uuid)
        {
            var res = await Task.FromResult(_programCategoryService.Delete(uuid));
            return res == null ? NotFound() : new Response("success");
        }
    }
}
