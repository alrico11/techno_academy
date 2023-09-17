using Microsoft.AspNetCore.Mvc;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;
using TechnoAcademyApi.Services;

namespace TechnoAcademyApi.Controllers
{
    [Route("api/v1/programentity")]
    [ApiController]
    public class ProgramEntityController : ControllerBase
    {
        private readonly IProgramEntityService _programEntityService;  
        public ProgramEntityController(IProgramEntityService programEntityService)
        {
            _programEntityService = programEntityService;
        }
        [HttpPost]
        public async Task<ActionResult<Response>> Create(ProgramEntity programEntity) { 
        
            var res = await Task.FromResult(_programEntityService.Create(programEntity));
            return res == null ? NotFound() : new Response("success");
        }
        [HttpGet]
        public async Task<ActionResult<Response>> GetAll()
        {
            var res = await Task.FromResult(_programEntityService.GetAll());
            return res == null ? NotFound() : new Response("success",res);
        }
        [HttpGet("{uuid}")]

        public async Task<ActionResult<Response>> GetByUUID(string uuid)
        {
            var res = await Task.FromResult(_programEntityService.GetByUUID(uuid));
            return res == null ? NotFound() : new Response("success",res);
        }

        [HttpPut("{uuid}")]
        public async Task<ActionResult<Response>> Update(string uuid,ProgramEntity programEntity) { 
            var res = await Task.FromResult(_programEntityService.Update(uuid, programEntity));
            return res == null ? NotFound() : new Response("success");
        }        
        [HttpPut("delete/{uuid}")]
        public async Task<ActionResult<Response>> DeleteByUUID(string uuid) { 
            var res = await Task.FromResult(_programEntityService.DeleteByUUID(uuid));
            return res == null ? NotFound() : new Response("success");
        }

        [HttpDelete("{uuid}")]
        public async Task<ActionResult<Response>> Delete(string uuid)
        {
            var res = await Task.FromResult(_programEntityService.Delete(uuid));
            return res == null ? NotFound() : new Response("success");
        }


    }
}
