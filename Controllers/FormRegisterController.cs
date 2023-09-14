using Microsoft.AspNetCore.Mvc;
using TechnoAcademyApi.Models.Dto.Res;
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
        public async Task<ActionResult<Response>> CreateFormRegister(FormRegister formRegister)
        {
            var result = await Task.FromResult(_formRegisterService.CreateFormRegister(formRegister));
            return result == null ? BadRequest() : new Response("success", result);
        }

        [HttpGet("{uuid}")]
        public async Task<ActionResult<Response>> GetFormRegisterByUUID(string uuid)
        {
            var result = await Task.FromResult(_formRegisterService.GetFormRegisterByUUID(uuid));
            return result == null ? NotFound() : new Response("success", result);
        }

        [HttpGet("/search/{email}")]
        public async Task<ActionResult<Response>> GetByEmail(string email)
        {
            var result = await Task.FromResult(_formRegisterService.GetByEmail(email));
            return result == null ? NotFound() : new Response("success", result);
        }
        [HttpGet]
        public async Task<ActionResult<Response>> GetAllFormRegisters()
        {
            var res = await Task.FromResult(_formRegisterService.GetAllFormRegisters());
            return res == null ? NotFound() : new Response("success", res);
        }

        [HttpPut("{uuid}")]
        public async Task<ActionResult<Response>> UpdateFormRegister(string uuid, FormRegister formRegister)
        {
            var res = await Task.FromResult(_formRegisterService.UpdateFormRegister(uuid, formRegister));
            return res == null ? NotFound() : new Response("success", res);
        }

        [HttpDelete("{uuid}")]
        public async Task<ActionResult<Response>> DeleteFormRegister(string uuid)
        {
            var res = await Task.FromResult(_formRegisterService.DeleteFormRegister(uuid));
            return res == null ? NotFound() : new Response("success", res);
        }
    }
}