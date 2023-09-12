using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create(GCMEntity entity)
        {
            var result = _entityService.Create(entity);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var res = _entityService.GetAll();
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("{uuid}")]
        public IActionResult GetByUUID(string uuid) {
            var res = _entityService.GetByUUID(uuid);
            if (res != null) {
                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut("{uuid}")]
        public IActionResult Update(string uuid, GCMEntity entity) {

            var res = _entityService.Update(uuid, entity);
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{uuid}")]
        public IActionResult Delete(string uuid) { 
            var res = _entityService.Delete(uuid);
            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("condition")]
        public IActionResult GetAllCondition()
        {

            var res = _entityService.GetCondition();
            return res == null ? NotFound() : Ok(res);
        }
        [HttpGet("condition/{condition}")]
        public IActionResult GetByCondition(string condition)
        {
            var res = _entityService.GetByCondition(condition);
            return res == null ? NotFound() : Ok(res);
        }
    }
}
