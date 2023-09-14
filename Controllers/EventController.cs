using Microsoft.AspNetCore.Mvc;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;
using TechnoAcademyApi.Services;

namespace TechnoAcademyApi.Controllers
{
    [Route("api/v1/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        [HttpPost]
        public async Task<ActionResult<Response>> Create(EventEntity entity)
        {
            var res = await Task.FromResult(_eventService.Create(entity));
            return res == null ? BadRequest() : new Response("success", res);
        }

        [HttpGet]
        public async Task<ActionResult<Response>> GetAll() { 
            var res = await Task.FromResult(_eventService.GetAll());
            return res == null ? BadRequest() : new Response("success", res);
        }
        [HttpGet("{uuid}")]
        public async Task<ActionResult<Response>> Get(string uuid) { 
            var res = await Task.FromResult(_eventService.GetById(uuid));
            return res == null ? NotFound() : new Response("success", res);
        }
        [HttpPut]
        public async Task<ActionResult<Response>> Update(string uuid, EventEntity entity)
        {
            var res = await Task.FromResult(_eventService.Update(uuid, entity));
            return res == null ? NotFound(res) : new Response("success");
        }
        [HttpDelete]

        public async Task<ActionResult<Response>> Delete(string uuid)
        {
            var res = await Task.FromResult(_eventService.Delete(uuid));
            return res == null ? NotFound(res) : new Response("success");
        }
    }
}
