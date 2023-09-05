using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create(ProgramEntity programEntity) { 
        
            var result = _programEntityService.Create(programEntity);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _programEntityService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("{uuid}")]

        public IActionResult GetByUUID(string uuid)
        {
            var result = _programEntityService.GetByUUID(uuid);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("{uuid}")]
        public IActionResult Update(string uuid,ProgramEntity programEntity) { 
            var result = _programEntityService.Update(uuid, programEntity);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("{uuid}")]
        public IActionResult Delete(string uuid)
        {
            var result = _programEntityService.Delete(uuid);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
