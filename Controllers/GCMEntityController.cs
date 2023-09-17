using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;
using TechnoAcademyApi.Services;

namespace TechnoAcademyApi.Controllers
{
    [Route("api/v1/gcm")]
    [ApiController]
    public class GCMEntityController : ControllerBase
    {
        private readonly IGCMEntityService _entityService;
        public GCMEntityController(IGCMEntityService entityService)
        {
            _entityService = entityService;
        }
        [HttpPost]
        public async Task<ActionResult<Response>> Create(GCMEntity entity)
        {
            var res = await Task.FromResult(_entityService.Create(entity));
            return res == null ? BadRequest() : new Response("success");
        }
        [HttpGet]
        public async Task<ActionResult<Response>> GetAll()
        {
            var res = await Task.FromResult(_entityService.GetAll());
            return res == null ? BadRequest() : new Response("success");
        }
        [HttpGet("{uuid}")]
        public async Task<ActionResult<Response>> GetByUUID(string uuid) {
            var res = await Task.FromResult(_entityService.GetByUUID(uuid));
            return res == null ? NotFound() : new Response("success", res);
        }
        [HttpPut("{uuid}")]
        public async Task<ActionResult<Response>> Update(string uuid, GCMEntity entity) {

            var res = await Task.FromResult(_entityService.Update(uuid, entity));
            return res == null ? NotFound() : new Response("success");
        }
        [HttpDelete("{uuid}")]
        public async Task<ActionResult<Response>> Delete(string uuid) { 
            var res = await Task.FromResult(_entityService.Delete(uuid));
            return res == null ? NotFound() : new Response("success");
        }
        [HttpPut("delete/{uuid}")]
        public async Task<ActionResult<Response>> DeleteByUUID(string uuid) { 
            var res = await Task.FromResult(_entityService.DeleteByUUID(uuid));
            return res == null ? NotFound() : new Response("success");
        }
        [HttpGet("condition")]
        public async Task<ActionResult<Response>> GetAllCondition()
        {
            var res = await Task.FromResult(_entityService.GetCondition());
            return res == null ? BadRequest() : new Response("success", res);
        }
        [HttpGet("condition/{condition}")]
        public async Task<ActionResult<Response>> GetByCondition(string condition)
        {
            var res = await Task.FromResult(_entityService.GetByCondition(condition));
            return res == null ? NotFound() : new Response("success",res);
        }
    }
}
