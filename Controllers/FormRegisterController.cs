using Microsoft.AspNetCore.Mvc;
using TechnoAcademyApi.Models.Entity;
using TechnoAcademyApi.Services;

namespace TechnoAcademyApi.Controllers
{
    [Route("api/v1/register")]
    [ApiController]
    public class FormRegisterController : ControllerBase
    {
        private readonly IFormRegisterService _formRegisterService;

        public FormRegisterController(IFormRegisterService formRegisterService)
        {
            _formRegisterService = formRegisterService;
        }

        [HttpPost]
        public IActionResult CreateFormRegister(FormRegister formRegister)
        {
            var result = _formRegisterService.CreateFormRegister(formRegister);
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
        public IActionResult GetFormRegisterByUUID(string uuid)
        {
            var result = _formRegisterService.GetFormRegisterByUUID(uuid);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpGet("/search/{email}")]
        public IActionResult GetByEmail(string email)
        {
            var result = _formRegisterService.GetByEmail(email);
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
        public IActionResult GetAllFormRegisters()
        {
            var result = _formRegisterService.GetAllFormRegisters();
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
        public IActionResult UpdateFormRegister(string uuid, FormRegister formRegister)
        {
            var result = _formRegisterService.UpdateFormRegister(uuid, formRegister);
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
        public IActionResult DeleteFormRegister(string uuid)
        {
            var result = _formRegisterService.DeleteFormRegister(uuid);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
    }
}