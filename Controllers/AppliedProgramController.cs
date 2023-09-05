using Microsoft.AspNetCore.Mvc;
using TechnoAcademyApi.Models.Entity;
using TechnoAcademyApi.Services;

namespace TechnoAcademyApi.Controllers
{
    [Route("api/v1/appliedprogram")]
    [ApiController]
    public class AppliedProgramController : ControllerBase
    {
        private readonly IAppliedProgramService _appliedProgramService;

        public AppliedProgramController(IAppliedProgramService appliedProgramService)
        {
            _appliedProgramService = appliedProgramService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _appliedProgramService.GetAll();
            if (result.Success) {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("{uuid}")]
        public IActionResult GetByUUID(string uuid) {
            var result = _appliedProgramService.GetByUUID(uuid);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost]
        public IActionResult Create(AppliedProgram appliedProgram)
        {
            var result = _appliedProgramService.Create(appliedProgram);
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
        public IActionResult Update(string uuid, AppliedProgram appliedProgram)
        {
            var result = _appliedProgramService.Update(uuid, appliedProgram);
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
            var result = _appliedProgramService.Delete(uuid);
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
