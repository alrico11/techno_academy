using Microsoft.AspNetCore.Mvc;
using TechnoAcademyApi.Models;
using TechnoAcademyApi.Services;

namespace TechnoAcademyApi.Controllers
{
    [Route("api/[controller]")]
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

        // Implement other CRUD operations (Read, Update, Delete) as needed
    }
}
