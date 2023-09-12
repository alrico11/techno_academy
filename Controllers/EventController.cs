using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create(EventEntity entity)
        {
            var res = _eventService.Create(entity);
            return Ok(res);
        }

        [HttpGet]
        public IActionResult GetAll() { 
            var res = _eventService.GetAll();
            return Ok(res);
        }
        [HttpGet("{uuid}")]
        public IActionResult Get(string uuid) { 
            var res = _eventService.GetById(uuid);
            return res == null ? NotFound(res) : Ok(res);
        }
        [HttpPut]
        public IActionResult Update(string uuid, EventEntity entity)
        {
            var res = _eventService.Update(uuid, entity);
            return res == null ? NotFound(res) : Ok(res);
        }
        [HttpDelete]

        public IActionResult Delete(string uuid)
        {
            var res = _eventService.Delete(uuid);
            return res == null ? NotFound(res) : Ok(res);
        }
    }
}
