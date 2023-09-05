using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create(MentorEntity entity)
        {
            var res = _service.Create(entity);
            if (res == null)
            {
                throw new Exception();
            }
            else
            {
                return Ok(res);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var res = _service.GetAll();
            if (res == null)
            {
                throw new Exception();
            }
            else
            {
                return Ok(res);
            }
        }
        [HttpGet("{uuid}")]
        public IActionResult GetByUUID(string uuid) { 
            var res = _service.GetByUUID(uuid);
            if (res == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(res);
            }
        }
        [HttpPut("{uuid}")]
        public IActionResult Put(string uuid, MentorEntity entity)
        {
            var res = _service.Update(uuid, entity);
            return res == null ? NotFound() : Ok(res);
        }

        [HttpDelete("{uuid}")]
        public IActionResult Delete(string uuid)
        {
            var res = _service.Delete(uuid);
            return res == null ? NotFound() : Ok(res);
        }
    }
}
