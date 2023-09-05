using Microsoft.AspNetCore.Mvc;
using TechnoAcademyApi.Models.Entity;
using TechnoAcademyApi.Services;

namespace TechnoAcademyApi.Controllers
{
    [Route("api/v1/programcategory")]
    [ApiController]
    public class ProgramCategoryController : ControllerBase
    {
        private readonly IProgramCategoryService _programCategoryService;
        
        public ProgramCategoryController(IProgramCategoryService programCategoryService)
        {
            _programCategoryService = programCategoryService;
        }

        [HttpPost]
        public IActionResult Create(ProgramCategory programCategory)
        {
            var result = _programCategoryService.Create(programCategory);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("{uuid}")]
        public IActionResult GetByUUID(string uuid)
        {
            var result = _programCategoryService.GetByUUID(uuid);
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
            var result = _programCategoryService.GetAll();
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
        public IActionResult Update(string uuid, ProgramCategory programCategory)
        {
            var result = _programCategoryService.Update(uuid,programCategory);
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
            var result = _programCategoryService.Delete(uuid);
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
