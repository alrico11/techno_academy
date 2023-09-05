using Microsoft.AspNetCore.Mvc;
using TechnoAcademyApi.Models.Entity;
using TechnoAcademyApi.Services;

namespace TechnoAcademyApi.Controllers
{
    [Route("api/v1/testimony")]
    [ApiController]
    public class TestimonyController : ControllerBase
    {
        private readonly ITestimonyService _testimonyService;
        public TestimonyController(ITestimonyService testimonyService)
        {
            _testimonyService = testimonyService;
        }
        [HttpPost]
        public IActionResult Create(TestimonyEntity entity)
        {
            var res = _testimonyService.Create(entity);
            return res == null ?  BadRequest(res) : Ok(res);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var res = _testimonyService.GetAll();
            return Ok(res);
        }
        [HttpGet("{uuid}")]
        public IActionResult GetByID(string uuid)
        {
            var res = _testimonyService.Get(uuid);
            return res == null ? NotFound(res) : Ok(res);
        }
        [HttpPut("{uuid}")]
        public IActionResult  Update(string uuid, TestimonyEntity entity)
        {
            var res = _testimonyService.Update(uuid, entity);
            return res == null ? NotFound(res) : Ok(res);
        }

        [HttpDelete("{uuid}")]
        public IActionResult Delete(string uuid)
        {
            var res = _testimonyService.Delete(uuid);
            return res == null ? NotFound(res) : Ok(res);
        }
    }
}
