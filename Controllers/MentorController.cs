using Microsoft.AspNetCore.Mvc;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;
using TechnoAcademyApi.Services;

namespace TechnoAcademyApi.Controllers
{
    [Route("api/v1/mentor")]
    [ApiController]
    public class MentorController : Controller
    {
        private readonly IMentorService _service;
        public MentorController(IMentorService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult<Response>> Create(MentorEntity entity)
        {
            var res = await Task.FromResult(_service.Create(entity));
            return res == null ? BadRequest() : new Response("success");
        }
        [HttpGet]
        public async Task<ActionResult<Response>> GetAll()
        {
            var res = await Task.FromResult(_service.GetAll());
            return res == null ? NotFound() : new Response("success", res);
        }
        [HttpGet("{uuid}")]
        public async Task<ActionResult<Response>> GetByUUID(string uuid) { 
            var res = await Task.FromResult(_service.GetByUUID(uuid));
            return res == null ? NotFound() : new Response("success", res);
        }
        [HttpPut("{uuid}")]
        public async Task<ActionResult<Response>> Update(string uuid, MentorEntity entity)
        {
            var res = await Task.FromResult(_service.Update(uuid, entity));
            return res == null ? NotFound() : new Response("success");
        }
        [HttpPut("delete/{uuid}")]
        public async Task<ActionResult<Response>> DeleteByUUID(string uuid)
        {
            var res = await Task.FromResult(_service.DeleteByUUID(uuid));
            return res == null ? NotFound() : new Response("success");
        }

        [HttpDelete("{uuid}")]
        public async Task<ActionResult<Response>> Delete(string uuid)
        {
            var res = await Task.FromResult(_service.Delete(uuid));
            return res == null ? NotFound() : new Response("success");
        }
    }
}
